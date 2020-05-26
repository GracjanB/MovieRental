namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenAccountAndVideoRentalTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoRentals", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoRentals", "AccountId");
            AddForeignKey("dbo.VideoRentals", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoRentals", "AccountId", "dbo.Accounts");
            DropIndex("dbo.VideoRentals", new[] { "AccountId" });
            DropColumn("dbo.VideoRentals", "AccountId");
        }
    }
}
