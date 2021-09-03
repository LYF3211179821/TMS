using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.VehicleService.Violation;

namespace TMS.Api.Controllers.VehicleService
{
    /// <summary>
    /// 服务-违章记录API
    /// </summary>
    [Route("ViolationAPI")]
    [ApiController]
    [ApiWrapResult]
    public class ViolationAPIController : ControllerBase
    {
        private readonly IBreakRulesRecordService _breakRules;

        public ViolationAPIController(IBreakRulesRecordService breakRules)
        {
            _breakRules = breakRules;
        }


        /// <summary>
        /// 违章记录显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetBreakRules")]
        public async Task<IActionResult> GetBreakRules()
        {
            return Ok(await _breakRules.GetBreakRules());
        }

    }
}
