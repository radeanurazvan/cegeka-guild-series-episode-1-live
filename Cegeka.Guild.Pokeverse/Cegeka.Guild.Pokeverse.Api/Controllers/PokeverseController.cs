using System;
using Microsoft.AspNetCore.Mvc;

namespace Cegeka.Guild.Pokeverse.Api.Controllers
{
    public abstract class PokeverseController : ControllerBase
    {
        protected IActionResult RunWithException(Action act, Func<IActionResult> onOk)
        {
            try
            {
                act();
                return onOk();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}