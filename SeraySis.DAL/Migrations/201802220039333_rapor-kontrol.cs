namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raporkontrol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rapor", "FirmaAdi", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Rapor", "Adres", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Rapor", "VergiNo", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Rapor", "VergiDairesi", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rapor", "VergiDairesi", c => c.String());
            AlterColumn("dbo.Rapor", "VergiNo", c => c.String());
            AlterColumn("dbo.Rapor", "Adres", c => c.String());
            AlterColumn("dbo.Rapor", "FirmaAdi", c => c.String());
        }
    }
}
