namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkartson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rapor", "NetTutar", c => c.Double(nullable: false));
            AddColumn("dbo.Rapor", "KdvliTutar", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rapor", "KdvliTutar");
            DropColumn("dbo.Rapor", "NetTutar");
        }
    }
}
