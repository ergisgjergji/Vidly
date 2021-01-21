using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult NewRentals(NewRentalsDto viewModel)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == viewModel.CustomerId);

            // Edge case
            if (viewModel.MovieIds.Count == 0)
                return BadRequest("MovieIds cannot be empty.");

            // Edge case
            if (customer == null)
                return BadRequest($"Customer with id {viewModel.CustomerId} was not found.");

            var movies = _context.Movies.Where(m => viewModel.MovieIds.Contains(m.Id)).ToList();

            // Edge casee
            if (movies.Count != viewModel.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach(var movie in movies)
            {
                // Edge case
                if (movie.NumberAvailable == 0)
                    return BadRequest($"Movie with id {movie.Id} is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentDate = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
