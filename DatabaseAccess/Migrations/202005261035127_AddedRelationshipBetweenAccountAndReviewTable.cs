namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenAccountAndReviewTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "AccountId");
            AddForeignKey("dbo.Reviews", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Reviews", new[] { "AccountId" });
            DropColumn("dbo.Reviews", "AccountId");
        }
    }
}
