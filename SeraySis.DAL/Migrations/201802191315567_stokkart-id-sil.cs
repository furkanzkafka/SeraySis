namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkartidsil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StokKart", "StokkartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StokKart", "StokkartId", c => c.Int(nullable: false));
        }
    }
}
