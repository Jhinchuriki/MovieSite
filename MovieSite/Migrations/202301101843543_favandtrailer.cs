namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favandtrailer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TrailerURL", c => c.String());
            AddColumn("dbo.Movies", "IsFavorite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsFavorite");
            DropColumn("dbo.Movies", "TrailerURL");
        }
    }
}
