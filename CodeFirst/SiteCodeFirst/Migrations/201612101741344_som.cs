namespace SiteCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class som : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
