namespace TrueForm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                        Name = c.String(),
                        ProductUrl = c.String(),
                        AmazonFetchType = c.String(),
                        AmazonProductIdTypeId = c.Int(),
                        BestBuyFetchType = c.String(),
                        BestBuyProductIdTypeId = c.Int(),
                        ProductTagLine = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.Guid(),
                        VideoUrl = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(),
                        SaleTypeId = c.Int(nullable: false),
                        IosLink = c.String(),
                        AndroidLink = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanySlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        SlotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.SlotId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.SlotId);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TierTypeId = c.Int(nullable: false),
                        KioskId = c.Int(nullable: false),
                        SlotName = c.String(),
                        JanPrice = c.Double(nullable: false),
                        FebPrice = c.Double(nullable: false),
                        MarPrice = c.Double(nullable: false),
                        AprPrice = c.Double(nullable: false),
                        MayPrice = c.Double(nullable: false),
                        JunePrice = c.Double(nullable: false),
                        JulyPrice = c.Double(nullable: false),
                        AugPrice = c.Double(nullable: false),
                        SepPrice = c.Double(nullable: false),
                        OctPrice = c.Double(nullable: false),
                        NovPrice = c.Double(nullable: false),
                        DecPrice = c.Double(nullable: false),
                        NextJanPrice = c.Double(nullable: false),
                        NextFebPrice = c.Double(nullable: false),
                        NextMarPrice = c.Double(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kiosks", t => t.KioskId, cascadeDelete: true)
                .Index(t => t.KioskId);
            
            CreateTable(
                "dbo.Kiosks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        Name = c.String(),
                        Neighborhood = c.String(),
                        AnnualAmount = c.Int(nullable: false),
                        NumberOfSlots = c.Int(nullable: false),
                        TierType1Slots = c.Int(nullable: false),
                        TierType2Slots = c.Int(nullable: false),
                        TierType1Weight = c.Double(nullable: false),
                        TierType2Weight = c.Double(nullable: false),
                        Overview = c.String(),
                        RegularHoursMondayToSaturday = c.String(),
                        RegularHoursSunday = c.String(),
                        HolidayHoursMondayToSaturday = c.String(),
                        HolidayHoursSunday = c.String(),
                        IsReserved = c.Boolean(nullable: false),
                        JanPercentage = c.Double(nullable: false),
                        FebPercentage = c.Double(nullable: false),
                        MarPercentage = c.Double(nullable: false),
                        AprPercentage = c.Double(nullable: false),
                        MayPercentage = c.Double(nullable: false),
                        JunePercentage = c.Double(nullable: false),
                        JulyPercentage = c.Double(nullable: false),
                        AugPercentage = c.Double(nullable: false),
                        SepPercentage = c.Double(nullable: false),
                        OctPercentage = c.Double(nullable: false),
                        NovPercentage = c.Double(nullable: false),
                        DecPercentage = c.Double(nullable: false),
                        NextJanPercentage = c.Double(nullable: false),
                        NextFebPercentage = c.Double(nullable: false),
                        NextMarPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        StreetAddress1 = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KioskStaffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KioskId = c.Int(nullable: false),
                        StaffMemberName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kiosks", t => t.KioskId, cascadeDelete: true)
                .Index(t => t.KioskId);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KioskId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        LeaseName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kiosks", t => t.KioskId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.KioskId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Leases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Leases", "KioskId", "dbo.Kiosks");
            DropForeignKey("dbo.KioskStaffs", "KioskId", "dbo.Kiosks");
            DropForeignKey("dbo.CompanySlots", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.Slots", "KioskId", "dbo.Kiosks");
            DropForeignKey("dbo.Kiosks", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.CompanySlots", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Products", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Products", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Leases", new[] { "ProductId" });
            DropIndex("dbo.Leases", new[] { "KioskId" });
            DropIndex("dbo.KioskStaffs", new[] { "KioskId" });
            DropIndex("dbo.Kiosks", new[] { "LocationId" });
            DropIndex("dbo.Slots", new[] { "KioskId" });
            DropIndex("dbo.CompanySlots", new[] { "SlotId" });
            DropIndex("dbo.CompanySlots", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "ReviewId" });
            DropIndex("dbo.Products", new[] { "CompanyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Leases");
            DropTable("dbo.KioskStaffs");
            DropTable("dbo.Locations");
            DropTable("dbo.Kiosks");
            DropTable("dbo.Slots");
            DropTable("dbo.CompanySlots");
            DropTable("dbo.Reviews");
            DropTable("dbo.Products");
            DropTable("dbo.Companies");
        }
    }
}
