using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saga.Poc.Saga.Zoo.App.Interfaces;
using Saga.Poc.Saga.Zoo.App.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Saga.Poc.Saga.Zoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DailyExtractLotsController : ControllerBase
    {
        private readonly IDailyExtractLotService _dailyExtractLotService;

        public DailyExtractLotsController(IDailyExtractLotService dailyExtractLotService)
        {
            _dailyExtractLotService = dailyExtractLotService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDailyExtractLotRequest request)
        {
            if (request == null)
                return BadRequest();

            await _dailyExtractLotService.CreateNewDailyExtractLot(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateDailyExtractLotRequest request)
        {
            if (request == null)
                return BadRequest();

            await _dailyExtractLotService.UpdateDailyExtractLot(request);

            return Ok();
        }

    }
}
