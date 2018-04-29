namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kodekle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StokKart", "Kod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StokKart", "Kod");
        }
    }
}
