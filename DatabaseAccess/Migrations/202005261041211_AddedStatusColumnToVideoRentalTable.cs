namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusColumnToVideoRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoRentals", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoRentals", "Status");
        }
    }
}
