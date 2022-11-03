using MovieSite.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieSite.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Reletionships 
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
