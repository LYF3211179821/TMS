using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TMS.Service.VehicleService.Maintain;
using TMS.Model.Entity.Vindicate;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 保养记录
    /// </summary>
    [Route("UpkeepRecordAPI")]
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
        /// <param name="UpkeepRecordName"></param>
        /// <param name="UpkeepRecordNowTime"></param>
        /// <param name="LicensePlateNumber"></param>
        /// <returns></returns>
        [HttpGet, Route("UpkeepRecordsList")]
        public IActionResult UpkeepRecordsList(string UpkeepRecordName, string UpkeepRecordNowTime, string LicensePlateNumber)
        {
            return Ok(_Upkeep.UpkeepRecordsList(UpkeepRecordName, UpkeepRecordNowTime, LicensePlateNumber));
        }
        /// <summary>
        /// 保养记录添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsAdd(UpkeepRecord obj)
        {
            return Ok(_Upkeep.UpkeepRecordsAdd(obj));
        }
        /// <summary>
        /// 保养记录删除
        /// </summary>
        /// <param name="UpkeepRecordID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsDel(string UpkeepRecordID)
        {
            return Ok(_Upkeep.UpkeepRecordsDel(UpkeepRecordID));
        }
        /// <summary>
        /// 保养记录反填
        /// </summary>
        /// <param name="UpkeepRecordsDel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpkeepRecordsDetails(int UpkeepRecordsDel)
        {
            return Ok(_Upkeep.UpkeepRecordsDetails(UpkeepRecordsDel));
        }
        /// <summary>
        /// 保养记录修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpkeepRecordsUpd(UpkeepRecord obj)
        {
            return Ok(_Upkeep.UpkeepRecordsUpd(obj));
        }

    }
}
