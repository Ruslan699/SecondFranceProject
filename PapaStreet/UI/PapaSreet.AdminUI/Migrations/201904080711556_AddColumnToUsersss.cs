namespace PapaSreet.AdminUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToUsersss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "ConfirmPassword");
        }
    }
}
