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

        [HttpGet("{initial}")]
        public IActionResult GetAllStartedBy(char initial) {
            return Ok(_service.GetAllStartedBy(initial));
        }

    }
}
