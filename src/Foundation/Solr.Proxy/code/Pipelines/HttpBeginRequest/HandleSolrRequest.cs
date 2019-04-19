using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines.HttpRequest;

namespace Foundation.SorlProxy.Pipelines.HttpBeginRequest
{
    public class HandleSolrRequest : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            var proxy = new Proxy();
            var argsContext = args.Context;
            if (proxy.GetSolrResponse(ref argsContext))
            {
                args.AbortPipeline();
            }
        }
    }
}