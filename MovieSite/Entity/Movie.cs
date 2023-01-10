using MovieSite.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSite.Entity
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public MovieCategory movieCategory { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string fileName { get; set; }

    }
}