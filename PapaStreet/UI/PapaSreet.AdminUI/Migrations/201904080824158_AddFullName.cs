namespace PapaSreet.AdminUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FullName", c => c.String(maxLength: 10));
            DropColumn("dbo.Users", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 10));
            DropColumn("dbo.Users", "FullName");
        }
    }
}
