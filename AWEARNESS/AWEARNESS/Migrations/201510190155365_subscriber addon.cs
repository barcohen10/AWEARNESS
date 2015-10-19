namespace AWEARNESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriberaddon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Birthday = c.DateTime(nullable: false),
                        Registration = c.DateTime(nullable: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Medicines = c.String(unicode: false),
                        Diseases = c.String(unicode: false),
                        Allergies = c.String(unicode: false),
                        SpecialInstructions = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PhoneNumber);
            
            CreateTable(
                "dbo.UserQRCodes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        QRCodeId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.QRCodeId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        EventId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.EventId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QRCodes",
                c => new
                    {
                        Pin = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(unicode: false),
                        ProductType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Pin);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Catagory = c.String(unicode: false),
                        PhoneNumberCaregiver = c.String(unicode: false),
                        EventType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Email = c.String(unicode: false),
                        IP = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserEvents", new[] { "UserId" });
            DropIndex("dbo.UserQRCodes", new[] { "UserId" });
            DropForeignKey("dbo.UserEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserQRCodes", "UserId", "dbo.Users");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Events");
            DropTable("dbo.QRCodes");
            DropTable("dbo.UserEvents");
            DropTable("dbo.UserQRCodes");
            DropTable("dbo.Users");
        }
    }
}
