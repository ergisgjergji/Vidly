using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Manager))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).Include(m => m.Genre).FirstOrDefault();

            return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = RoleName.Manager)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormVm() { Genres = genres };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Manager)]
        public ActionResult New(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var model = new MovieFormVm()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View(model);
            }

            movie.NumberAvailable = movie.NumberInStock;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = RoleName.Manager)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Where(c => c.Id == id).FirstOrDefault();

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormVm()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Manager)]
        public ActionResult Edit(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var model = new MovieFormVm()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View(model);
            }

            var dbMovie = _context.Movies.Where(c => c.Id == movie.Id).Single();

            dbMovie.Name = movie.Name;
            dbMovie.ReleaseDate = movie.ReleaseDate;
            dbMovie.AddedDate = movie.AddedDate;
            dbMovie.GenreId = movie.GenreId;
            dbMovie.NumberInStock = movie.NumberInStock;
            dbMovie.NumberAvailable = movie.NumberInStock;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}