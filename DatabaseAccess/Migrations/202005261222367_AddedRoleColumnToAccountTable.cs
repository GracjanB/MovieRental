namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoleColumnToAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Role");
        }
    }
}
