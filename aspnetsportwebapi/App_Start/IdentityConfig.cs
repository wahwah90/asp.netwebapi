using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using aspnetsportwebapi.Infrastructure.Identity;
[assembly: OwinStartup(typeof(aspnetsportwebapi.IdentityConfig))]

namespace aspnetsportwebapi
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<StoreIdentityDbContext>(StoreIdentityDbContext.Create);
            app.CreatePerOwinContext<StoreUserManager>(StoreUserManager.Create);
            app.CreatePerOwinContext<StoreRoleManager>(StoreRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}