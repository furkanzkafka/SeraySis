namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faturatarih : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rapor", "FaturaTarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rapor", "FaturaTarih");
        }
    }
}
