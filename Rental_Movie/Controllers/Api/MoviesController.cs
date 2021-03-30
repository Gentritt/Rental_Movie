using AutoMapper;
using Rental_Movie.Dtos;
using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Movie_Rental.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private static ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //get/movies/

        //public IHttpActionResult GetMovies(string query = null)
        //{
        //    var moviesquery = _context.Movies.Include(c => c.genre);
        //    if (!String.IsNullOrWhiteSpace(query))
        //        moviesquery = moviesquery.Where(c => c.Name.Contains(query));
        //    var moviesdto = moviesquery.ToList()
        //        .Select(Mapper.Map<Movie, MovieDto>);
        //    return Ok(moviesdto);
        //}
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.genre);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var moviesDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }
        //get/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            var movieinDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movieinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieinDb);
            _context.SaveChanges();
        }
        [HttpDelete]

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();

        }
    }
}
