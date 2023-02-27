namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Rated = c.Int(nullable: false),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comments", "Username", c => c.String());
            AddColumn("dbo.Movies", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Votes");
            DropColumn("dbo.Comments", "Username");
            DropTable("dbo.Ratings");
        }
    }
}
