using System.Web.Http;
using WebApi.App_Start;
using WebApi.Helpers;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);           
        }
    }

}
