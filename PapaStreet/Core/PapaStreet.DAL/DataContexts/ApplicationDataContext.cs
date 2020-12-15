using Microsoft.AspNet.Identity.EntityFramework;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DAOs.UserDAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DataContexts
{
   public class ApplicationDataContext:IdentityDbContext<UserDao,RoleDao,Guid,UserLoginDao,UserRoleDao,UserClaimsDao>          
    {
        public ApplicationDataContext() : base("PapaStreetConStr") { }

        public ApplicationDataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public static ApplicationDataContext Create()
        {
            return new ApplicationDataContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<UserDao>().ToTable("Users").Property(x => x.Id).HasColumnName("UserId");
            //modelBuilder.Entity<ApplicationUser>().ToTable("AppUsers").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<UserRoleDao>().ToTable("UserRoles");/*.HasKey(ur => new { ur.UserId, ur.RoleId });*/
            modelBuilder.Entity<UserLoginDao>().ToTable("UserLogins");/*.HasKey(ur => new { ur.UserId });*/
            modelBuilder.Entity<UserClaimsDao>().ToTable("UserClaims");
            modelBuilder.Entity<RoleDao>().ToTable("Roles");
        }


    }
}
