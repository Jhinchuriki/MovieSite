namespace MovieSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "fileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "fileName");
        }
    }
}
