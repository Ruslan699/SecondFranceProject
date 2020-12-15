namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegionAndDepartamentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartamentCities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DepartamentId = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        CreatedUserId = c.Guid(),
                        ModifiedUserId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Depataments", t => t.DepartamentId)
                .Index(t => t.DepartamentId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartamentCities", "DepartamentId", "dbo.Depataments");
            DropForeignKey("dbo.DepartamentCities", "CityId", "dbo.Cities");
            DropIndex("dbo.DepartamentCities", new[] { "CityId" });
            DropIndex("dbo.DepartamentCities", new[] { "DepartamentId" });
            DropTable("dbo.DepartamentCities");
        }
    }
}
