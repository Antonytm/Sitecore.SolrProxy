using System;
using System.IO;
using System.Net;
using System.Web;

namespace Foundation.SolrProxy
{
    public class Proxy
    {
        public readonly string SolrSitecorePath = "/sitecore/shell/solr";
        public readonly string SolrOriginPath = "/solr";
        public bool GetSolrResponse(ref HttpContext context)
        {
            
            var path = context.Request.Url.PathAndQuery;
            if (!path.StartsWith(SolrSitecorePath, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            
            if (Sitecore.Context.User.IsInRole(@"sitecore\Developer") || Sitecore.Context.IsAdministrator)
            {
                if (path.Equals(SolrSitecorePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    context.Response.Redirect($"{SolrSitecorePath}/");
                    context.Response.End();
                }

                var remoteUrl = $"{GetSolrServer()}{path.Replace(SolrSitecorePath, SolrOriginPath)}";
                var request = (HttpWebRequest)WebRequest.Create(remoteUrl);
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException webException)
                {
                    Sitecore.Diagnostics.Log.Error($"Unable to get response from Solr server", webException, this);
                    //remote url not found, send 404 to client 
                    context.Response.StatusCode = 500;
                    context.Response.StatusDescription = "Unable to proxy request to Solr";
                    context.Response.Write("Unable to proxy request to Solr");
                    context.Response.End();

                    return true;
                }

                var receiveStream = response.GetResponseStream();


                var buff = new byte[1024];
                var bytes = 0;
                while ((bytes = receiveStream.Read(buff, 0, 1024)) > 0)
                {
                    //Write the stream directly to the client 
                    context.Response.OutputStream.Write(buff, 0, bytes);
                }

                //close streams
                response.Close();
                context.Response.ContentType = response.ContentType;
                context.Response.End();

                return true;
            }


            else
            {
                context.Response.Redirect("/sitecore/login");
                context.Response.End();
            }

            return false;
        }

        private static string GetSolrServer()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["solr.search"].ConnectionString.Replace("/solr", "");
        }
    }
}