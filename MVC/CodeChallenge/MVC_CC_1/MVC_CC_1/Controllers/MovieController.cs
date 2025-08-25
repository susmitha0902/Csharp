using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CC_1.Models.CodeFirst;
using MVC_CC_1.Repositories;

namespace MVC_CC_1.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo = new MovieRepository();
        // GET: Movie
        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Add(movie);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }
        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View(movies);
        }

    }
}




   

      

       





