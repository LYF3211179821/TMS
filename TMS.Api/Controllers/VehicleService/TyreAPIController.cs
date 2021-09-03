using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.VehicleService.Tyre;

namespace TMS.Api.Controllers.VehicleService
{
    /// <summary>
    /// 服务-轮胎记录API
    /// </summary>
    [Route("TyreAPI")]
    [ApiController]
    [ApiWrapResult]
    public class TyreAPIController : ControllerBase
    {
        private readonly ITyreUseRecordService _tyre;

        public TyreAPIController(ITyreUseRecordService tyre)
        {
            _tyre = tyre;
        }

        /// <summary>
        /// 轮胎记录显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetTyres")]
        public async Task <IActionResult> GetTyres()
        {
            return Ok(await _tyre.GetTyres());
        }

    }
}
