using System;
using System.Collections.Generic;
using DAL.model;
using DAL.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProductWebAPI.Infrastructure;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    [AuthRequired]
    public class RentalController: ControllerBase {


        private readonly RentalService _service;


        public RentalController(RentalService service) {
            _service = service;
        }

        [HttpPost]
        public IActionResult add( IEnumerable<int> movies) {

            int customerId = (int)ControllerContext.RouteData.Values["CustomerId"];

            try {
                return Ok(_service.Insert(movies, customerId));
            }catch(Exception e) {

            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll() {
            int customerId = (int)ControllerContext.RouteData.Values["CustomerId"];
            return Ok(_service.GetAll(customerId));
        }

        [HttpGet("{Id}")]
        public Rental GetById(int Id) {
            int customerId = (int)ControllerContext.RouteData.Values["CustomerId"];
            return _service.Get(Id, customerId);
        }

    }
}
