namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenVideoAndVideoRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoRentals", "VideoId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoRentals", "VideoId");
            AddForeignKey("dbo.VideoRentals", "VideoId", "dbo.Videos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoRentals", "VideoId", "dbo.Videos");
            DropIndex("dbo.VideoRentals", new[] { "VideoId" });
            DropColumn("dbo.VideoRentals", "VideoId");
        }
    }
}
