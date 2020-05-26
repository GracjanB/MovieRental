namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 256),
                        Firstname = c.String(nullable: false, maxLength: 64),
                        Lastname = c.String(nullable: false, maxLength: 64),
                        IsActive = c.Boolean(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 4000),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateStart = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateEnd = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Price = c.Decimal(nullable: false, storeType: "smallmoney"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        Category = c.Int(),
                        ProductionYear = c.Int(),
                        Description = c.String(maxLength: 4000),
                        Country = c.String(maxLength: 64),
                        Director = c.String(maxLength: 64),
                        Scenario = c.String(maxLength: 64),
                        PricePerDay = c.Decimal(nullable: false, storeType: "smallmoney"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
            DropTable("dbo.VideoRentals");
            DropTable("dbo.Reviews");
            DropTable("dbo.Accounts");
        }
    }
}
