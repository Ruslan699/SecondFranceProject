namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnnouncementId = c.Guid(nullable: false),
                        Image = c.Binary(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.AnnouncementId)
                .Index(t => t.AnnouncementId);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        AnnouncementTypeId = c.Guid(nullable: false),
                        PropertyTypeId = c.Guid(nullable: false),
                        DocumentTypeId = c.Guid(nullable: false),
                        RepairId = c.Guid(nullable: false),
                        Title = c.String(),
                        ContactPerson = c.String(),
                        Email = c.String(),
                        VendorType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PropertyDescription = c.String(),
                        Address = c.String(),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomCount = c.Int(nullable: false),
                        FloorCount = c.Int(nullable: false),
                        CurrentFloor = c.Int(nullable: false),
                        ViewsCount = c.Int(nullable: false),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnnouncementTypes", t => t.AnnouncementTypeId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeId)
                .ForeignKey("dbo.Repairs", t => t.RepairId)
                .Index(t => t.CityId)
                .Index(t => t.AnnouncementTypeId)
                .Index(t => t.PropertyTypeId)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.RepairId);
            
            CreateTable(
                "dbo.AnnouncementTypes",
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
            
            CreateTable(
                "dbo.Cities",
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
            
            CreateTable(
                "dbo.DocumentTypes",
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
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnnouncementId = c.Guid(nullable: false),
                        Number = c.String(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.AnnouncementId)
                .Index(t => t.AnnouncementId);
            
            CreateTable(
                "dbo.PropertyTypes",
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
            
            CreateTable(
                "dbo.Repairs",
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
            
            CreateTable(
                "dbo.CustomerPhones",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Number = c.String(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        About = c.String(),
                        Address = c.String(),
                        Image = c.Binary(),
                        Email = c.String(),
                        Password = c.String(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPhones", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Announcements", "RepairId", "dbo.Repairs");
            DropForeignKey("dbo.Announcements", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.PhoneNumbers", "AnnouncementId", "dbo.Announcements");
            DropForeignKey("dbo.Announcements", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Announcements", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Announcements", "AnnouncementTypeId", "dbo.AnnouncementTypes");
            DropForeignKey("dbo.AnnouncementImages", "AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.CustomerPhones", new[] { "CustomerId" });
            DropIndex("dbo.PhoneNumbers", new[] { "AnnouncementId" });
            DropIndex("dbo.Announcements", new[] { "RepairId" });
            DropIndex("dbo.Announcements", new[] { "DocumentTypeId" });
            DropIndex("dbo.Announcements", new[] { "PropertyTypeId" });
            DropIndex("dbo.Announcements", new[] { "AnnouncementTypeId" });
            DropIndex("dbo.Announcements", new[] { "CityId" });
            DropIndex("dbo.AnnouncementImages", new[] { "AnnouncementId" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerPhones");
            DropTable("dbo.Repairs");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.AnnouncementTypes");
            DropTable("dbo.Announcements");
            DropTable("dbo.AnnouncementImages");
        }
    }
}
