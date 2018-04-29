namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokkontrol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StokKart", "MalzemeTanim", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.StokKart", "BirimPara", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StokKart", "BirimPara", c => c.String());
            AlterColumn("dbo.StokKart", "MalzemeTanim", c => c.String(nullable: false));
        }
    }
}
