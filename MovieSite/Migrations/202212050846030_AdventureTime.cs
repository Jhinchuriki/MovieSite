namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdventureTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
