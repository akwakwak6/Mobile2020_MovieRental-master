using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.model;
using DAL.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController: ControllerBase {

        private readonly ActorService _service;

        public ActorController(ActorService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }


        [HttpGet("{Id}")]
        public Actor GetById(int Id) {
            return _service.Get(Id);
        }

    }
}
