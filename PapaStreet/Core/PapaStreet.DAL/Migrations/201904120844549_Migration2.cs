namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "SourceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "SourceType");
        }
    }
}
