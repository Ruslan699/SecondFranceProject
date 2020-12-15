namespace PapaStreet.DAL.IdentityMigrations
{
    using PapaStreet.Common.Helpers;
    using PapaStreet.DAL.DAOs;
    using PapaStreet.DAL.DataContexts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<PapaStreet.DAL.DataContexts.ApplicationDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"IdentityMigrations";
        }

        protected override void Seed(PapaStreet.DAL.DataContexts.ApplicationDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //SetAdmin(context);
        }

        private void SetAdmin(ApplicationDataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(new UserDao()
                {
                    Id = Guid.NewGuid(),

                    Email = "admin@gmail.com",

                    UserName = "admin123",

                    PasswordHash = HashHelper.ComputeHash("admin123")
                });
            }
        }
    }
}
