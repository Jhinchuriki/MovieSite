using Microsoft.AspNetCore.Mvc.Rendering;
using MovieSite.Controllers;
using MovieSite.Entity;
using MovieSite.ViewModel.Shared;
using System.ComponentModel;

namespace MovieSite.ViewModel.MovieVM
{
    public class DisplayVM
    {
        public List<Movie> Movies { get; set; }
        public HomeController homeController { get; set; }
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }
    }
}
