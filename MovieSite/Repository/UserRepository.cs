using MovieSite.Entity;
using MovieSite.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MovieSite.Repository
{
    public class UsersRepository
    {
        private  AppDbContext context;
       
        public UsersRepository()
        {
            this.context = new AppDbContext();
        }
        public bool UserExisting(int id)
        {
            foreach (var item in context.Users)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddUser(User item)
        {
            User user = new User();

            user.username = item.username;
            user.password = item.password;   
            user.email = item.email;
            user.IsAdmin = item.IsAdmin;
            context.Users.Add(user);

            context.SaveChanges();
        }
        public void DeleteUser(int id)
        {            
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
        public void UpdateUser(User item)
        {
            User user = context.Users.Find(item.Id);

            user.username = item.username;
            user.email = item.email;
            user.password = item.password;
            user.IsAdmin = item.IsAdmin;
            context.Entry(user).State = EntityState.Modified; //potencialno shte trqq se iztrie
            context.SaveChanges();
        }
        public List<User> GetAll(Expression<Func<User, bool>> filter = null, int page = 1, int pageSize = int.MaxValue)
        {
            IQueryable<User> query = context.Users;

            if (filter != null)
                query = query.Where(filter);

            return query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public User getByEmailAndPassword(string email, string password)
        {
            foreach (var item in context.Users)
            {
                if (item.email == email && item.password == password)
                {
                    return item;
                }
            }
            return null;
        }
        public int UsersCount(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = context.Users;

            if (filter != null)
                query = query.Where(filter);

            return query.Count();
        }
      
    }
}