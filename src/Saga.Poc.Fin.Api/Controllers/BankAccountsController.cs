using Saga.Poc.Saga.Fin.App.Interfaces;
using Saga.Poc.Saga.Fin.App.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBankAccountRequest request)
        {
            if (request == null)
                return BadRequest();

            await _bankAccountService.CreateNewBankAccount(request);

            return Ok();
        }
    }
}
