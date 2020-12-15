namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishDataAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "PublishedDate", c => c.DateTime());
            AddColumn("dbo.Announcements", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "ExpirationDate");
            DropColumn("dbo.Announcements", "PublishedDate");
        }
    }
}
