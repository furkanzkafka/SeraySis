namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkartyeter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StokKart", "StokkartId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StokKart", "StokkartId");
        }
    }
}
