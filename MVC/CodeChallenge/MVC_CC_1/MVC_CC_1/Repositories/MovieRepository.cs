using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_CC_1.Models.CodeFirst;

namespace MVC_CC_1.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesDbContext db = new MoviesDbContext();
        public IEnumerable<Movie> GetAll() => db.Movies.ToList();
        public Movie GetById(int id) => db.Movies.Find(id);
        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
        public void Update(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
        public IEnumerable<Movie> GetByYear(int year) =>
            db.Movies.Where(m => m.DateofRelease.Year == year).ToList();
        public IEnumerable<Movie> GetByDirector(string directorName) =>
            db.Movies.Where(m => m.DirectorName == directorName).ToList();
    }
}



