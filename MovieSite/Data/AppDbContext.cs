using MovieSite.Models;
using System.Data.Entity;
using System.Collections.Generic;


namespace MovieSite.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("Sever=localhost\\sqlexpress;Database=MovieSite;Trusted_Connection=True;")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasKey(m=>m.Movie).WithMany()
            base.OnModelCreating(modelBuilder);
        }
    }
}
