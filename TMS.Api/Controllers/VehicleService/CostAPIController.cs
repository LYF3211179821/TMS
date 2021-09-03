using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.VehicleService.Cost;

namespace TMS.Api.Controllers.VehicleService
{
    /// <summary>
    /// 服务-费用记录API
    /// </summary>
    [Route("CostAPI")]
    [ApiController]
    [ApiWrapResult]
    public class CostAPIController : ControllerBase
    {
        private readonly ICostRecordService _cost;

        public CostAPIController(ICostRecordService cost)
        {
            _cost = cost;
        }

        /// <summary>
        /// 费用显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCosts")]
        public async Task<IActionResult> GetCosts()
        {
            return Ok(await _cost.GetCosts());
        }

    }
}
