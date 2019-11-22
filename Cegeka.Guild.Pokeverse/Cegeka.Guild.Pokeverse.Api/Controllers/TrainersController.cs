using System;
using Cegeka.Guild.Pokeverse.Api.Models;
using Cegeka.Guild.Pokeverse.BLL.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Cegeka.Guild.Pokeverse.Api.Controllers
{
    [Route("api/trainers")]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService service;

        public TrainersController(ITrainerService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPost("")]
        public IActionResult Register([FromBody] RegisterTrainerModel model)
        {
            try
            {
                this.service.Register(model.Name);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}