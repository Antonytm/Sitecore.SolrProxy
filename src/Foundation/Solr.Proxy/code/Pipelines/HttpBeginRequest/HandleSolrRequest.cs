using Sitecore.Pipelines.HttpRequest;

namespace Foundation.SolrProxy.Pipelines.HttpBeginRequest
{
    public class HandleSolrRequest : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            var proxy = new Proxy();
            var argsContext = args.HttpContext.ApplicationInstance.Context;
            if (proxy.GetSolrResponse(ref argsContext))
            {
                args.AbortPipeline();
            }
        }
    }
}