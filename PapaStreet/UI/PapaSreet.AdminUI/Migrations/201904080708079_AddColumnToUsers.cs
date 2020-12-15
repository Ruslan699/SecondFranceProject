namespace PapaSreet.AdminUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "FirstName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 10));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 15));
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Discriminator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.AppUsers", "FirstName");
        }
    }
}
