using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TMS.Service.VehicleService.Maintain;
using TMS.Model.Entity.Vindicate;
using TMS.Common.MyFilters;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 服务-保养记录API
    /// </summary>
    [Route("UpkeepRecordAPI")]
    [ApiController]
    [ApiWrapResult]
    public class UpkeepRecordAPIController : Controller
    {
        public IUpkeepRecordsService _Upkeep;

        public UpkeepRecordAPIController(IUpkeepRecordsService Upkeep)
        {
            _Upkeep = Upkeep;
        }


        /// <summary>
        /// 保养记录显示
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("UpkeepRecordsList")]
        public async Task<IActionResult> GetUpkeepRecords()
        {
            return Ok( await _Upkeep.GetUpkeepRecords());
        }
        

    }
}
