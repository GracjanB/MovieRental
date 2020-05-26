namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenVideoAndReviewTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "VideoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "VideoId");
            AddForeignKey("dbo.Reviews", "VideoId", "dbo.Videos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "VideoId", "dbo.Videos");
            DropIndex("dbo.Reviews", new[] { "VideoId" });
            DropColumn("dbo.Reviews", "VideoId");
        }
    }
}
