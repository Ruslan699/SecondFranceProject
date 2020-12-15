using System;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.Utils;

namespace PapaSreet.AdminUI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, UserDao, Guid>(
                        TimeSpan.FromMinutes(30),
                        (manager, user) => user.GenerateUserIdentityAsync(manager),
                        GetUserIdCallBack)
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }

        private Guid GetUserIdCallBack(ClaimsIdentity arg)
        {
            var idClaimValue = arg.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(idClaimValue))
                return new Guid();
            return Guid.Parse(idClaimValue);
        }
    }
}