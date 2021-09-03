using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.Contract.Carry;

namespace TMS.Api.Controllers.Contract
{
    /// <summary>
    /// 合同管理-承运合同
    /// </summary>
    [Route("CarryAPI")]
    [ApiController]
    [ApiWrapResult]
    public class CarryAPIController : ControllerBase
    {
        private readonly ICarryService _carry;

        public CarryAPIController(ICarryService carry)
        {
            _carry = carry;
        }


        /// <summary>
        /// 承运合同显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetAccepts")]
        public async Task<IActionResult> GetAccepts()
        {
            return Ok(await _carry.GetAccepts());
        }

    }
}
