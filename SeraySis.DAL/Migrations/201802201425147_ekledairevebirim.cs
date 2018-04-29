namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ekledairevebirim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rapor", "VergiDairesi", c => c.String());
            AddColumn("dbo.StokKart", "BirimPara", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StokKart", "BirimPara");
            DropColumn("dbo.Rapor", "VergiDairesi");
        }
    }
}
