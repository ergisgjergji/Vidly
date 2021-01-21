using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize]
    public class MoviesController : ApiController
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

        // GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(m => Mapper.Map<Movie, MovieDto>(m));

            return Ok(movies);
        }

        // GET /api/movies/available
        [HttpGet]
        [Route("api/movies/available")]
        public IHttpActionResult GetMoviesAvailable(string query = null)
        {
            var moviesQuery = _context.Movies.Where(m => m.NumberAvailable > 0).Include(m => m.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movies = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        // GET /api/movie/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok( Mapper.Map<Movie, MovieDto>(movie) );
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            Mapper.Map(movie, movieDto);

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            Mapper.Map(movieDto, movie);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
