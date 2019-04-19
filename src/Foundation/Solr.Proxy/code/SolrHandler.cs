using System.Web;
using System.Web.SessionState;

namespace Foundation.SorlProxy
{
    public class SolrHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            var proxy = new Proxy();
            proxy.GetSolrResponse(ref context);
        }

        public bool IsReusable { get; }
    }
}