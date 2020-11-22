using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.service;
using DAL.model;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController: ControllerBase {

        private readonly MovieService _service;

        public MoviesController(MovieService service) {
            _service = service;
        }


        [HttpGet("{Id}")]
        public Movie GetById(int Id) {
            return _service.Get(Id);
        }



    }
}
