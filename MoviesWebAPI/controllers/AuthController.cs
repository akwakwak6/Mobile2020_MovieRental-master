using DAL.model;
using DAL.service;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Infrastructure;
using System;

namespace MoviesWebAPI.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase {
        private readonly AuthService _service;
        private readonly TokenService _tokenService;

        public AuthController(AuthService service, TokenService tokenService) {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Customer c) {
            try {
                _service.Register(c);
                return Ok();
            }catch(Exception e) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Customer c) {
            try {
                c = _service.Login(c);
            }catch(Exception e) {
                return BadRequest();
            }
            if (c is null)
                return Unauthorized();

            c.Token = _tokenService.GenerateToken(c);
            return Ok(c);
        }
    }
}