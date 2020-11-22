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
    public class InitialActorController: ControllerBase {

        private readonly InitialActorService _service;

        public InitialActorController(InitialActorService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }


        [HttpGet("{Id}")]
        public InitialActor GetById(int Id) {
            return _service.Get(Id);
        }

    }
}
