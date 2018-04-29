namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkartidekle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rapor", "StokKart_Id", "dbo.StokKart");
            DropIndex("dbo.Rapor", new[] { "StokKart_Id" });
            RenameColumn(table: "dbo.Rapor", name: "StokKart_Id", newName: "StokkartId");
            AlterColumn("dbo.Rapor", "StokkartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rapor", "StokkartId");
            AddForeignKey("dbo.Rapor", "StokkartId", "dbo.StokKart", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rapor", "StokkartId", "dbo.StokKart");
            DropIndex("dbo.Rapor", new[] { "StokkartId" });
            AlterColumn("dbo.Rapor", "StokkartId", c => c.Int());
            RenameColumn(table: "dbo.Rapor", name: "StokkartId", newName: "StokKart_Id");
            CreateIndex("dbo.Rapor", "StokKart_Id");
            AddForeignKey("dbo.Rapor", "StokKart_Id", "dbo.StokKart", "Id");
        }
    }
}
