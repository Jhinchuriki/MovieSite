using MovieSite.Entity;
using System.Data.Entity;
using System.Collections.Generic;


namespace MovieSite.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public AppDbContext() : base("Server=localhost\\sqlexpress;Database=MovieSite;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            Movies = this.Set<Movie>();
        }
       
    }
}
