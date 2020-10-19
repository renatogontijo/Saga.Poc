using Saga.Poc.Saga.Fin.App.Interfaces;
using Saga.Poc.Saga.Fin.App.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BuyCattlesController : ControllerBase
    {
        private readonly IBuyCattleService _buyCattleService;

        public BuyCattlesController(IBuyCattleService buyCattleService)
        {
            _buyCattleService = buyCattleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BuyCattleRegisterNewRequest request)
        {
            if (request == null)
                return BadRequest();

            await _buyCattleService.BuyCattleRegisterNew(request);

            return Ok();
        }
    }
}
