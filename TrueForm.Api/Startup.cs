using System.Configuration;
using System.Web.Http;
using Owin; 
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth; 
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.IocManager;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using TrueForm.Api.Utilities;
using IocManager = TrueForm.Api.Utilities.IocManager;

namespace TrueForm.Api
{
    public class Startup
    {

        // These values are pulled from web.config
        public static string aadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
        public static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        public static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string signUpPolicy = ConfigurationManager.AppSettings["ida:SignUpPolicyId"];
        public static string signInPolicy = ConfigurationManager.AppSettings["ida:SignInPolicyId"];
        public static string editProfilePolicy = ConfigurationManager.AppSettings["ida:UserProfilePolicyId"];

        public void Configuration(IAppBuilder app)
        {
            //HttpConfiguration config = new HttpConfiguration();

            //Web API routes
            //config.MapHttpAttributeRoutes();
            

            ConfigureDi(app);
            
            ConfigureOAuth(app);
            

        }

        private static void ConfigureDi(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());

            //builder
            //    .RegisterType<ApplicationOAuthProvider>()
            //    .As<IOAuthAuthorizationServerProvider>()
            //    .PropertiesAutowired() // to automatically resolve IUserService
            //    .SingleInstance(); // you only need one instance of this provider


            //builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
            //    .InstancePerRequest();
            //builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //builder.RegisterType<TicketDataFormat>().As<ISecureDataFormat<AuthenticationTicket>>();

            //builder.RegisterType<TicketSerializer>().As<IDataSerializer<AuthenticationTicket>>();
            //builder.Register(c => new DpapiDataProtectionProvider("TrueForm").Create("ASP.NET Identity"))
            //    .As<IDataProtector>();

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            app.UseCors(CorsOptions.AllowAll);

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc().UseCors(CorsOptions.AllowAll);
            app.UseAutofacWebApi(GlobalConfiguration.Configuration).UseCors(CorsOptions.AllowAll);
            
            IocManager.Instance.IocContainer = container;
        }
         
        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(CreateBearerOptionsFromPolicy(signUpPolicy));
            app.UseOAuthBearerAuthentication(CreateBearerOptionsFromPolicy(signInPolicy));
            app.UseOAuthBearerAuthentication(CreateBearerOptionsFromPolicy(editProfilePolicy));
        }

        private OAuthBearerAuthenticationOptions CreateBearerOptionsFromPolicy(string policy)
        {
            var metadataEndpoint = string.Format(aadInstance, tenant, policy);

            TokenValidationParameters tvps = new TokenValidationParameters
            {
                // This is where you specify that your API only accepts tokens from its own clients
                ValidAudience = clientId,
                AuthenticationType = policy,
                NameClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier"
            };

            return new OAuthBearerAuthenticationOptions
            {
                // This SecurityTokenProvider fetches the Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
                AccessTokenFormat = new JwtFormat(tvps, new OpenIdConnectCachingSecurityTokenProvider(metadataEndpoint))
            };
        }
    }
}