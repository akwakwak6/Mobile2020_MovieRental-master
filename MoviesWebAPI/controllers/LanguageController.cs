using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController: ControllerBase {

        private readonly LangageService _service;

        public LanguageController(LangageService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }

    }
}
