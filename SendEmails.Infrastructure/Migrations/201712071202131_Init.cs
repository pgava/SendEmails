namespace SendEmails.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailProviderParam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailProviderId = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailProvider", t => t.EmailProviderId, cascadeDelete: true)
                .Index(t => t.EmailProviderId);
            
            CreateTable(
                "dbo.EmailProvider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailProviderId = c.Int(nullable: false),
                        EmailTo = c.String(),
                        EmailCc = c.String(),
                        EmailBcc = c.String(),
                        SendDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailProvider", t => t.EmailProviderId, cascadeDelete: true)
                .Index(t => t.EmailProviderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Email", "EmailProviderId", "dbo.EmailProvider");
            DropForeignKey("dbo.EmailProviderParam", "EmailProviderId", "dbo.EmailProvider");
            DropIndex("dbo.Email", new[] { "EmailProviderId" });
            DropIndex("dbo.EmailProviderParam", new[] { "EmailProviderId" });
            DropTable("dbo.Email");
            DropTable("dbo.EmailProvider");
            DropTable("dbo.EmailProviderParam");
        }
    }
}
