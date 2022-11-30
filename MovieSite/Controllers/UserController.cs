using Microsoft.AspNetCore.Mvc;
using MovieSite.Entity;
using MovieSite.Data;
using MovieSite.Service;
using MovieSite.Repository;
using MovieSite.ViewModel.UserVM;
using MovieSite.ViewModel.Shared;

namespace ProjectManager.Controllers
{
    public class UsersController : Controller
    {
        //------------------LOGOUT-------------------------------//
        public IActionResult Logout()
        {
            Authentication.LoggedUser = null;
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------------------------//
        //------------------REGISTER SCREEN----------------------//
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(RegisterVM item)
        {
            if (!ModelState.IsValid)
                return View(item);

            UsersRepository usersRepository = new UsersRepository();
            User user = new User();

            user.username = item.Username;
            user.password = item.Password;
            user.email = item.Email;
            user.IsAdmin = false;
            usersRepository.AddUser(user);
            Authentication.LoggedUser = user;

            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------------------------//
        //------------------LOGIN SCREEN-------------------------//
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            Authentication.GetInfoToLoggedUser(Email, Password);

            if (Authentication.LoggedUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        //-------------------------------------------------------//
        //------------------DISPLAYS ALL USERS-------------------//
        public IActionResult UserList(IndexVM model)
        {
            if (Authentication.LoggedUser != null)
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

                UsersRepository usersRepository = new UsersRepository();
                model.Items = usersRepository.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
                model.Pager.PagesCount = (int)Math.Ceiling(usersRepository.UsersCount(filter) / (double)model.Pager.ItemsPerPage);

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //-------------------------------------------------------//
        //------------------ADD METHOD---------------------------//
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM item)
        {
            if (!ModelState.IsValid)
                return View(item);

            UsersRepository userRepo = new UsersRepository();
            User user = new User();
            user.username = item.Username;
            user.password = item.Password;
            user.email = item.Email;
          

            userRepo.AddUser(user);

            if (Authentication.LoggedUser.IsAdmin)
            {
                return RedirectToAction("UserList", "Users");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //------------------------------------------------------//
        //------------------DELETING USER METHOD----------------//
        public IActionResult DeleteUser(int id)
        {
            UsersRepository userRepo = new UsersRepository();
           
            userRepo.DeleteUser(id);

            return RedirectToAction("UserList", "Users");
        }
        //------------------------------------------------------//
        //------------------UPDATE USER-------------------------//
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            AppDbContext context = new AppDbContext();
            User user = context.Users.Find(id);
            EditVM item = new EditVM();

            item.ID = user.Id;
            item.Username = user.username;
            item.Password = user.password;
            item.Email = user.email;
            item.IsAdmin = user.IsAdmin;

            return View(item);
        }
        [HttpPost]
        public IActionResult UpdateUser(EditVM item)
        {
            UsersRepository userRepo = new UsersRepository();
            User user = new User();
            item.ID = user.Id;
            item.Username = user.username;
            item.Password = user.password;
            item.Email = user.email;
            item.IsAdmin = user.IsAdmin;


            userRepo.UpdateUser(user);

            return RedirectToAction("UserList", "Users");
        }
        //------------------------------------------------------//
    }
}
