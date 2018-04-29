namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kodkaldir : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StokKart", "Kod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StokKart", "Kod", c => c.Guid(nullable: false));
        }
    }
}
