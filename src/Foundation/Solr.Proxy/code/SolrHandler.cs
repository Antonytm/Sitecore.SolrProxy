using System.Web;

namespace Foundation.CSSGridLayout
{
    public class SolrHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var proxy = new Proxy();
            proxy.GetSolrResponse(ref context);
        }

        public bool IsReusable { get; }
    }
}