using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;

namespace TMS.Service.VehicleService.Accident
{
    public interface IAccidentRecordService
    {
        /// <summary>
        /// 显示事故记录
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="carNum"></param>
        /// <returns></returns>
        Task<List<AccidentRecord>> GetAccidentRecords(string title, DateTime? date, string carNum);
    }
}
