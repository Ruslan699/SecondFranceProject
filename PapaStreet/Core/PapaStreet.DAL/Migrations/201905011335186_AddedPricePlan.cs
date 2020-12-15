namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPricePlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PricePlans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FrequencyId = c.Guid(nullable: false),
                        DurationId = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AnnouncementCount = c.Int(nullable: false),
                        BonusAnnouncementCount = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Frequencies", t => t.DurationId)
                .ForeignKey("dbo.Frequencies", t => t.FrequencyId)
                .Index(t => t.FrequencyId)
                .Index(t => t.DurationId);
            
            CreateTable(
                "dbo.Frequencies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DaysCount = c.Int(nullable: false),
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
                "dbo.PricePlanHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        FromPricePlanId = c.Guid(nullable: false),
                        ToPricePlanId = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UsedAnnouncementCount = c.Int(nullable: false),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.PricePlans", t => t.FromPricePlanId)
                .ForeignKey("dbo.PricePlans", t => t.ToPricePlanId)
                .Index(t => t.CustomerId)
                .Index(t => t.FromPricePlanId)
                .Index(t => t.ToPricePlanId);
            
            AddColumn("dbo.Customers", "PricePlanId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Customers", "PricePlanId");
            AddForeignKey("dbo.Customers", "PricePlanId", "dbo.PricePlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PricePlanHistories", "ToPricePlanId", "dbo.PricePlans");
            DropForeignKey("dbo.PricePlanHistories", "FromPricePlanId", "dbo.PricePlans");
            DropForeignKey("dbo.PricePlanHistories", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "PricePlanId", "dbo.PricePlans");
            DropForeignKey("dbo.PricePlans", "FrequencyId", "dbo.Frequencies");
            DropForeignKey("dbo.PricePlans", "DurationId", "dbo.Frequencies");
            DropIndex("dbo.PricePlanHistories", new[] { "ToPricePlanId" });
            DropIndex("dbo.PricePlanHistories", new[] { "FromPricePlanId" });
            DropIndex("dbo.PricePlanHistories", new[] { "CustomerId" });
            DropIndex("dbo.PricePlans", new[] { "DurationId" });
            DropIndex("dbo.PricePlans", new[] { "FrequencyId" });
            DropIndex("dbo.Customers", new[] { "PricePlanId" });
            DropColumn("dbo.Customers", "PricePlanId");
            DropTable("dbo.PricePlanHistories");
            DropTable("dbo.Frequencies");
            DropTable("dbo.PricePlans");
        }
    }
}
