using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_CC_1.Models.CodeFirst;
namespace MVC_CC_1.Repositories
{
    public interface IMovieRepository
    { 
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string directorName);
    }
}




