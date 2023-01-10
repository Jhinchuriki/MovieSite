using Microsoft.AspNetCore.Mvc;
using MovieSite.Entity;
using MovieSite.Data;
using MovieSite.Repository;
using MovieSite.ViewModel.MovieVM;
using MovieSite.Data.Enums;
using MovieSite.ViewModel.Shared;



namespace MovieSite.Controllers
{

    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MovieController(IWebHostEnvironment webhost)
        {
            _webHostEnvironment = webhost;
        }
        public IActionResult Details()
        {
            return View();
        }
        
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult MovieAdmin(DisplayVM model)
        {
            model.Pager ??= new PagerVM();
            model.Filter ??= new FilterVM();
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 10
                                        : model.Pager.ItemsPerPage;

            model.Pager.Page = model.Pager.Page <= 0
                                    ? 1
                                    : model.Pager.Page;

            var filter = model.Filter.GetFilter();

            MovieRepository movieRepository = new MovieRepository();
            model.Movies = movieRepository.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(movieRepository.MovieCount(filter) / (double)model.Pager.ItemsPerPage);

            return View(model);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM item,IFormFile file)
        {
            MovieRepository movieRepo = new MovieRepository();
            Movie movie = new Movie();

            if (file != null)
            {
                movie.fileName = item.file.FileName.Substring(0, file.FileName.Length - 4);

                var path = Path.Combine(_webHostEnvironment.WebRootPath + "\\img", file.FileName);

                using var fileStream = new FileStream(path, FileMode.Create);
                file.CopyTo(fileStream);
            }



            movie.Title = item.Title;
            movie.Description = item.Description;
            movie.movieCategory = item.MovieCategory;
            movie.fileName = file.FileName;
            movieRepo.InsertMovie(movie);
            return RedirectToAction("MovieAdmin", "Movie");
        }
        //------------------------------------------------------//
        //------------------DELETING Movie METHOD----------------//
        public IActionResult DeleteMovie(int id)
        {
            MovieRepository movieRepo = new MovieRepository();

            movieRepo.DeleteMovieByID(id);

            return RedirectToAction("MovieAdmin", "Movie");
        }


        //------------------------------------------------------//
        //------------------UPDATE Movie METHOD-------------------------//
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            AppDbContext context = new AppDbContext();
            Movie movie = context.Movies.Find(id);// no idea if this is right
            EditVM item = new EditVM();

            item.ID = movie.Id;
            movie.Title = item.Title;
            movie.Description = item.Description;
            movie.movieCategory = item.MovieCategory;//should edit Movie.EditVM

            return View(item);
        }
        [HttpPost]
        public IActionResult UpdateMovie(EditVM item)
        {
            MovieRepository movieRepo = new MovieRepository();
            Movie movie = new Movie();
            movie.Id = item.ID;
            movie.Title = item.Title;
            movie.Description = item.Description;
            movie.movieCategory = item.MovieCategory;//should edit Movie.EditVM



            movieRepo.UpdateMovie(movie);

            return RedirectToAction("MovieAdmin", "Movie");//redirect to somewhere???
        }
        //------------------------------------------------------//

    }
}