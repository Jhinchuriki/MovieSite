namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Movies", "IsFavorite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "IsFavorite", c => c.Boolean(nullable: false));
            DropTable("dbo.Favourites");
        }
    }
}
