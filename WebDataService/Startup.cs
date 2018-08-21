using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebDataService.Providers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using NLog.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(WebDataService.Startup))]
namespace WebDataService
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            //HttpConfiguration config = new HttpConfiguration();
            //System.Web.Mvc.AreaRegistration.RegisterAllAreas();
            //ConfigureOAuth(app);
            //config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
            //GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            //UnityConfig.RegisterComponents(config);

            HttpConfiguration = new HttpConfiguration();
            ConfigureOAuth(app);
            HttpConfiguration.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            HttpConfiguration.Formatters.Add(new JsonPatch.Formatting.JsonPatchFormatter());
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(HttpConfiguration);
            app.UseWebApi(HttpConfiguration);
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            UnityConfig.RegisterComponents(HttpConfiguration);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ADAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}