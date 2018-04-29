namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faturakodekle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rapor", "FaturaKod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rapor", "FaturaKod");
        }
    }
}
