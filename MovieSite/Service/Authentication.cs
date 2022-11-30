using MovieSite.Entity;
using MovieSite.Data;
using MovieSite.Repository;

namespace MovieSite.Service
{
    public class Authentication
    {
        public static User LoggedUser { get; set; }
        public static void GetInfoToLoggedUser(string username , string password)
        {
            AppDbContext context = new AppDbContext();
            UsersRepository controller = new UsersRepository();
            LoggedUser = controller.getByUsernameAndPassword(username, password);
        }
    }
}
