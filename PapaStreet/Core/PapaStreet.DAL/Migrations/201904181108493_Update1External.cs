namespace PapaStreet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1External : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GenericAnnouncements");
            AddColumn("dbo.GenericAnnouncements", "ExternalId", c => c.String());
            AddColumn("dbo.GenericAnnouncements", "CreatedUserId", c => c.Guid());
            AddColumn("dbo.GenericAnnouncements", "ModifiedUserId", c => c.Guid());
            AddColumn("dbo.GenericAnnouncements", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GenericAnnouncements", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.GenericAnnouncements", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.GenericAnnouncements", "Version", c => c.Int(nullable: false));
            AlterColumn("dbo.GenericAnnouncements", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.GenericAnnouncements", "Id");

            Sql("ALTER TABLE [dbo].[GenericAnnouncements] ALTER COLUMN ExternalID VARCHAR(25)");
            Sql("ALTER TABLE[dbo].[GenericAnnouncements] ADD   CONSTRAINT UC_GM_EX_ID UNIQUE(ExternalID)");
        }
        
        public override void Down()
        {
            Sql(@"ALTER TABLE [dbo].[GenericAnnouncements] DROP CONSTRAINT UC_GM_EX_ID;");

            DropPrimaryKey("dbo.GenericAnnouncements");
            AlterColumn("dbo.GenericAnnouncements", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.GenericAnnouncements", "Version");
            DropColumn("dbo.GenericAnnouncements", "Status");
            DropColumn("dbo.GenericAnnouncements", "ModifiedDate");
            DropColumn("dbo.GenericAnnouncements", "CreatedDate");
            DropColumn("dbo.GenericAnnouncements", "ModifiedUserId");
            DropColumn("dbo.GenericAnnouncements", "CreatedUserId");
            DropColumn("dbo.GenericAnnouncements", "ExternalId");
            AddPrimaryKey("dbo.GenericAnnouncements", "ID");
            
        }
    }
}
