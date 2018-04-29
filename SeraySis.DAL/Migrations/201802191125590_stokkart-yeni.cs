namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkartyeni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rapor", "Adres", c => c.String());
            AddColumn("dbo.Rapor", "VergiNo", c => c.String());
            AddColumn("dbo.Rapor", "MiktarLitre", c => c.Double(nullable: false));
            AddColumn("dbo.Rapor", "ToplamTutar", c => c.Double(nullable: false));
            AddColumn("dbo.StokKart", "Kod", c => c.Guid(nullable: false));
            DropColumn("dbo.Rapor", "Tutar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rapor", "Tutar", c => c.Int(nullable: false));
            DropColumn("dbo.StokKart", "Kod");
            DropColumn("dbo.Rapor", "ToplamTutar");
            DropColumn("dbo.Rapor", "MiktarLitre");
            DropColumn("dbo.Rapor", "VergiNo");
            DropColumn("dbo.Rapor", "Adres");
        }
    }
}
