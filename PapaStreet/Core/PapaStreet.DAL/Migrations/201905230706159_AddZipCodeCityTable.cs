namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZipCodeCityTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "CurrentFloorName", c => c.String());
            AddColumn("dbo.Cities", "ZipCode", c => c.String());
            AddColumn("dbo.Cities", "ZipCodeAndName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "ZipCodeAndName");
            DropColumn("dbo.Cities", "ZipCode");
            DropColumn("dbo.Announcements", "CurrentFloorName");
        }
    }
}
