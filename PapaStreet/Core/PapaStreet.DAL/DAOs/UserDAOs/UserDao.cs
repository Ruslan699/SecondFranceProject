using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PapaStreet.DAL.DAOs.UserDAOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("Users")]
    public class UserDao : IdentityUser<Guid, UserLoginDao, UserRoleDao, UserClaimsDao>
    {
        public UserDao()
        {
            Id = Guid.NewGuid();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserDao, Guid> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(DAOs.Claims.PhoneNumber, PhoneNumber));
            return userIdentity;
        }
    }
}
