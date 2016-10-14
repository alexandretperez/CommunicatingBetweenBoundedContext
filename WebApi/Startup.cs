using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApi;
using WebApi.App_Start;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApi
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            SimpleInjectorWebApiInitializer.Initialize(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        }
    }
}