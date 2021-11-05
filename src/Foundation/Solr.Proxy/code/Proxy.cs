using System;
using System.IO;
using System.Net;
using System.Web;

namespace Foundation.SorlProxy
{
    public class Proxy
    {
        public bool GetSolrResponse(ref HttpContextBase context)
        {
            var path = context.Request.Url.PathAndQuery;
            if (path.StartsWith("/solr", StringComparison.InvariantCultureIgnoreCase))
            {
                if (Sitecore.Context.User.IsInRole(@"sitecore\Developer") || Sitecore.Context.IsAdministrator)
                {
                    if (path.Equals("/solr", StringComparison.InvariantCultureIgnoreCase))
                    {
                        context.Response.Redirect("/solr/");
                        context.Response.End();
                    }

                    var remoteUrl = $"{GetSolrServer()}{path}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(remoteUrl);
                    HttpWebResponse response;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (System.Net.WebException we)
                    {
                        Sitecore.Diagnostics.Log.Error($"Unable to get response from Solr server", we, this);
                        //remote url not found, send 404 to client 
                        context.Response.StatusCode = 404;
                        context.Response.StatusDescription = "Not Found";
                        context.Response.Write("<h2>Page not found</h2>");
                        context.Response.End();

                        return true;
                    }

                    Stream receiveStream = response.GetResponseStream();


                    var buff = new byte[1024];
                    int bytes = 0;
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
            }

            return false;
        }

        private string GetSolrServer()
        {
            return Sitecore.Configuration.Settings.GetSetting("ContentSearch.Solr.ServiceBaseAddress").Replace("/solr", "");
        }
    }
}