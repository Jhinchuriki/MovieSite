namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "IsFavorite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsFavorite");
        }
    }
}
