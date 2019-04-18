﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Foundation.CSSGridLayout
{
    public class Proxy
    {
        public void GetSolrResponse(ref HttpContext context)
        {
            var path = context.Request.Url.PathAndQuery;
            if (path.StartsWith("/solr"))
            {
                var remoteUrl = $"{GetSolrServer()}{path}";
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(remoteUrl);
                //request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse) request.GetResponse();
                }
                catch (System.Net.WebException we)
                {
                    //remote url not found, send 404 to client 
                    context.Response.StatusCode = 404;
                    context.Response.StatusDescription = "Not Found";
                    context.Response.Write("<h2>Page not found</h2>");
                    context.Response.End();
                    return;
                }

                Stream receiveStream = response.GetResponseStream();


                //the response is not HTML 
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


            }
        }

        private string GetSolrServer()
        {
            return Sitecore.Configuration.Settings.GetSetting("ContentSearch.Solr.ServiceBaseAddress").Replace("/solr","");
        }
    }
}