using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.VehicleService.Repair;

namespace TMS.Api.Controllers.VehicleService
{
    /// <summary>
    /// 服务-维修记录API
    /// </summary>
    [Route("RepairAPI")]
    [ApiController]
    [ApiWrapResult]
    public class RepairAPIController : ControllerBase
    {
        private readonly IMaintainRecordService _maintain;

        public RepairAPIController(IMaintainRecordService maintain)
        {
            _maintain = maintain;
        }


        /// <summary>
        /// 显示维修记录
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetMaintainRecords")]
        public async Task<IActionResult> GetMaintainRecords()
        {
            return Ok(await _maintain.GetMaintainRecords());
;        }

    }
}
