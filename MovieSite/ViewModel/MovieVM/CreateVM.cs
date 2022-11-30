using System.ComponentModel.DataAnnotations;

namespace MovieSite.ViewModel.MovieVM
{
    public class CreateVM
    {
        [Display(Name = "Title: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Title { get; set; }
        [Display(Name = "Desciption: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Description { get; set; }

    }
}
