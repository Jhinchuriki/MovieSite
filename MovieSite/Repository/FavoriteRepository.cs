using MovieSite.Entity;
using MovieSite.Repository;
using MovieSite.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MovieSite.Repository
{
    public class FavoriteRepository
    {
        private readonly AppDbContext context;
        private readonly MovieRepository movieRepository;
        public FavoriteRepository()
        {
            movieRepository = new MovieRepository();
            context = new AppDbContext();
        }
        public void isFavorite(int favoriteId,int movieid)
        {
            Movie movie = movieRepository.GetById(movieid);
            
            if (movie.IsFavorite)
            {
                Favorite favorite = context.Favorites.Find(favoriteId);
                DeleteFavoriteByID(favorite.Id);
                movie.IsFavorite = false;

            }
            else
            {
                Favorite favorite = new Favorite();
                favorite.UserId = favoriteId;
                favorite.MovieId = movie.Id;
                InsertFavorite(favorite);
                movie.IsFavorite = true;
            }

            movieRepository.UpdateMovie(movie);
        } 
        public void InsertFavorite(Favorite item)
        {
            Favorite favorite = new Favorite();

            favorite.UserId = item.UserId;
            favorite.MovieId = item.MovieId;
            

            context.Favorites.Add(favorite);
            context.SaveChanges();
        }
        public void DeleteFavoriteByID(int id)
        {

            Favorite favorite = context.Favorites.Find(id);

            context.Favorites.Remove(favorite);

            context.SaveChanges();
        }
        public int FindFavoriteId(int movieid, int userId)
        {
            foreach (var item in context.Favorites)
            {
                if (item.MovieId == movieid && item.UserId == userId)
                {
                    return item.Id;
                }
            }
            return -1;
        }
        public List<Movie> getAllFavorites(int userId)
        {
            return (from a in context.Movies
                    join b in context.Favorites on a.Id equals b.MovieId
                    where b.UserId == userId
                    select a).ToList();                
        }

    }
}
