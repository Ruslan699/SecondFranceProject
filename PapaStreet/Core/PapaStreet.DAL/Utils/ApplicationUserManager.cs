using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;

namespace PapaStreet.DAL.Utils
{
    public class ApplicationUserManager : UserManager<UserDao, Guid>
    {
        public ApplicationUserManager(IUserStore<UserDao, Guid> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<UserDao, RoleDao, Guid, UserLoginDao, UserRoleDao, UserClaimsDao>(new ApplicationDataContext("PapaStreetConStr")));

            manager.UserValidator = new UserValidator<UserDao, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                //RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<UserDao, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
