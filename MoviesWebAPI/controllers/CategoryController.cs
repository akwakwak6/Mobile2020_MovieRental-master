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
    public class CategoryController: ControllerBase {

        private readonly CategoryService _service;

        public CategoryController(CategoryService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }


        [HttpGet("{Id}")]
        public Category GetById(int Id) {
            return _service.Get(Id);
        }

    }
}
