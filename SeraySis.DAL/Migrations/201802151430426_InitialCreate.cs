namespace SeraySis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rapor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Tutar = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        Username = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 30),
                        ProfileImage = c.String(maxLength: 30),
                        ActivateGuid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Rapor");
        }
    }
}
