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
        private readonly TokenService _tokenService;


        public RentalController(RentalService service,TokenService tokenService) {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult add( IEnumerable<int> movies) {

            int CostumerId = _tokenService.getCustomerId(Request.Headers[HeaderNames.Authorization]);

            try {
                return Ok(_service.Insert(movies, CostumerId));
            }catch(Exception e) {

            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll() {
            int CostumerId = _tokenService.getCustomerId(Request.Headers[HeaderNames.Authorization]);
            return Ok(_service.GetAll(CostumerId));
        }

        [HttpGet("{Id}")]
        public Rental GetById(int Id) {
            int CostumerId = _tokenService.getCustomerId(Request.Headers[HeaderNames.Authorization]);
            return _service.Get(Id, CostumerId);
        }

    }
}
