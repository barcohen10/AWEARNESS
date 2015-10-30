namespace AWEARNESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Registration = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Medicines = c.String(),
                        Diseases = c.String(),
                        Allergies = c.String(),
                        SpecialInstructions = c.String(),
                    })
                .PrimaryKey(t => t.PhoneNumber);
            
            CreateTable(
                "dbo.UserQRCodes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        QRCodeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.QRCodeId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        EventId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.EventId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QRCodes",
                c => new
                    {
                        Pin = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(),
                        ProductType = c.String(),
                    })
                .PrimaryKey(t => t.Pin);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Catagory = c.String(),
                        PhoneNumberCaregiver = c.String(),
                        EventType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Email = c.String(),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserContacts",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ContactUserId = c.String(nullable: false, maxLength: 128),
                        Relationship = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.ContactUserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserContacts", new[] { "UserId" });
            DropIndex("dbo.UserEvents", new[] { "UserId" });
            DropIndex("dbo.UserQRCodes", new[] { "UserId" });
            DropForeignKey("dbo.UserContacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserQRCodes", "UserId", "dbo.Users");
            DropTable("dbo.UserContacts");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Events");
            DropTable("dbo.QRCodes");
            DropTable("dbo.UserEvents");
            DropTable("dbo.UserQRCodes");
            DropTable("dbo.Users");
        }
    }
}
