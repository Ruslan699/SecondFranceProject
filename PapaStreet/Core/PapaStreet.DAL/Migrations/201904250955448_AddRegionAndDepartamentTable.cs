namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegionAndDepartamentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depataments",
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
                "dbo.RegionDepartaments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegionId = c.Guid(nullable: false),
                        DepartamentId = c.Guid(nullable: false),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depataments", t => t.DepartamentId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.RegionId)
                .Index(t => t.DepartamentId);
            
            CreateTable(
                "dbo.Regions",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegionDepartaments", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.RegionDepartaments", "DepartamentId", "dbo.Depataments");
            DropIndex("dbo.RegionDepartaments", new[] { "DepartamentId" });
            DropIndex("dbo.RegionDepartaments", new[] { "RegionId" });
            DropTable("dbo.Regions");
            DropTable("dbo.RegionDepartaments");
            DropTable("dbo.Depataments");
        }
    }
}
