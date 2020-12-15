namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCalculatedColumnPriceDouble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenericAnnouncements", "PriceDouble", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GenericAnnouncements", "PriceDouble");
        }
    }
}
