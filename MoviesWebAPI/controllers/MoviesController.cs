using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.service;
using DAL.model;
using System.Collections.Generic;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController: ControllerBase {

        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService) {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<MovieList> GetAllList() {
            return _movieService.GetAllMovieList();
        }

        [HttpGet("{Id}")]
        public Movie GetFilmById(int Id) {
            return _movieService.Get(Id);
        }

        [HttpPost]
        public IEnumerable<MovieList> GetMovieListFiltered([FromBody] FilterMovie fm) {
            return _movieService.GetMovieListFillted(fm);
        }

        

    }
}
