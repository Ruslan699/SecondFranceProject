namespace PapaSreet.AdminUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FullName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FullName", c => c.String(maxLength: 10));
        }
    }
}
