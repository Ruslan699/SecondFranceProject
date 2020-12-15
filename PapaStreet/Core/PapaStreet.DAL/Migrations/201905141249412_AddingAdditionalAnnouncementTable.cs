namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdditionalAnnouncementTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementAdditions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Announcements", "AnnouncementAddition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "AnnouncementAddition");
            DropTable("dbo.AnnouncementAdditions");
        }
    }
}
