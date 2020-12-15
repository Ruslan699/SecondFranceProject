namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenericAnnouncement : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Announcements", new[] { "RepairId" });
            AddColumn("dbo.GenericAnnouncements", "AnnouncementTypeId", c => c.Guid());
            AddColumn("dbo.GenericAnnouncements", "PropertyTypeId", c => c.Guid());
            AddColumn("dbo.GenericAnnouncements", "Area", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.GenericAnnouncements", "RoomCount", c => c.Int());
            AddColumn("dbo.GenericAnnouncements", "FloorCount", c => c.Int());
            AddColumn("dbo.GenericAnnouncements", "CurrentFloor", c => c.Int());
            AddColumn("dbo.GenericAnnouncements", "AnnouncementAddition", c => c.String());
            AlterColumn("dbo.Announcements", "RepairId", c => c.Guid());
            CreateIndex("dbo.Announcements", "RepairId");
            CreateIndex("dbo.GenericAnnouncements", "AnnouncementTypeId");
            CreateIndex("dbo.GenericAnnouncements", "PropertyTypeId");
            AddForeignKey("dbo.GenericAnnouncements", "AnnouncementTypeId", "dbo.AnnouncementTypes", "Id");
            AddForeignKey("dbo.GenericAnnouncements", "PropertyTypeId", "dbo.PropertyTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenericAnnouncements", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.GenericAnnouncements", "AnnouncementTypeId", "dbo.AnnouncementTypes");
            DropIndex("dbo.GenericAnnouncements", new[] { "PropertyTypeId" });
            DropIndex("dbo.GenericAnnouncements", new[] { "AnnouncementTypeId" });
            DropIndex("dbo.Announcements", new[] { "RepairId" });
            AlterColumn("dbo.Announcements", "RepairId", c => c.Guid(nullable: false));
            DropColumn("dbo.GenericAnnouncements", "AnnouncementAddition");
            DropColumn("dbo.GenericAnnouncements", "CurrentFloor");
            DropColumn("dbo.GenericAnnouncements", "FloorCount");
            DropColumn("dbo.GenericAnnouncements", "RoomCount");
            DropColumn("dbo.GenericAnnouncements", "Area");
            DropColumn("dbo.GenericAnnouncements", "PropertyTypeId");
            DropColumn("dbo.GenericAnnouncements", "AnnouncementTypeId");
            CreateIndex("dbo.Announcements", "RepairId");
        }
    }
}
