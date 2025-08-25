using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_CC_1.Models.CodeFirst
{
    public class MoviesDbContext:DbContext
    {
        public MoviesDbContext() : base("MoviesDB") { }
        public DbSet<Movie> Movies { get; set; }
    }
}
 
