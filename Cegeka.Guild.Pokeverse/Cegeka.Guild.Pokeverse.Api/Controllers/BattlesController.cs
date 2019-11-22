using System;
using Cegeka.Guild.Pokeverse.Api.Models;
using Cegeka.Guild.Pokeverse.BLL.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Cegeka.Guild.Pokeverse.Api.Controllers
{
    [Route("api/trainers")]
    public class BattlesController : PokeverseController
    {
        private readonly IBattleService service;

        public BattlesController(IBattleService service)
        {
            this.service = service;
        }

        [HttpPost("")]
        public IActionResult Start([FromBody] StartBattleModel model)
        {
            return RunWithException(
                () => this.service.StartBattle(model.AttackerId, model.DefenderId), Ok);
        }
    }
}