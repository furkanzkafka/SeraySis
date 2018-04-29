namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StokKart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MalzemeTanim = c.String(nullable: false),
                        KdvOran = c.Double(nullable: false),
                        BirimFiyat = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rapor", "StokKart_Id", c => c.Int());
            CreateIndex("dbo.Rapor", "StokKart_Id");
            AddForeignKey("dbo.Rapor", "StokKart_Id", "dbo.StokKart", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rapor", "StokKart_Id", "dbo.StokKart");
            DropIndex("dbo.Rapor", new[] { "StokKart_Id" });
            DropColumn("dbo.Rapor", "StokKart_Id");
            DropTable("dbo.StokKart");
        }
    }
}
