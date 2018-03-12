using Nancy.Metadata.Swagger.Modules;
using Nancy.Routing;
using System.Threading.Tasks;

namespace Nancy.Metadata.Swagger.DemoApplication.Modules
{
    public class DocsModule : SwaggerDocsModuleBase
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider) : base(routeCacheProvider, "/api/docs", "Sample API documentation", "v1.0", "localhost:5000", "/api", "http")
        {
            Get["/", true] = async (x, ct) => await Task.Run(() => Response.AsRedirect("/Content/index.html"));
        }
    }
}