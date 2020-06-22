using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrueForm.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
        }
    }
}
