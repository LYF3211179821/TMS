using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.VehicleService.Accident;

namespace TMS.Api.Controllers.VehicleService
{
    /// <summary>
    /// 服务-事故记录API
    /// </summary>
    [Route("AccidentAPI")]
    [ApiController]
    [ApiWrapResult]
    public class AccidentAPIController : ControllerBase
    {
        private readonly IAccidentRecordService _accident;

        public AccidentAPIController(IAccidentRecordService accident)
        {
            _accident = accident;
        }


        /// <summary>
        /// 显示事故记录
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="carNum"></param>
        /// <returns></returns>
        [HttpGet,Route("GetAccidentRecords")]
        public async Task<IActionResult> GetAccidentRecords(string title, DateTime? date, string carNum)
        {
            return Ok(await _accident.GetAccidentRecords(title, date, carNum));
        }

    }
}
