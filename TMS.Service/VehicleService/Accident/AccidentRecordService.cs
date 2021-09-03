using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.VehicleService;
using TMS.Model.Entity.Vindicate;

namespace TMS.Service.VehicleService.Accident
{
    public class AccidentRecordService: IAccidentRecordService
    {
        private readonly IAccidentRecordRepository _accident;

        public AccidentRecordService(IAccidentRecordRepository accident)
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
        public async Task<List<AccidentRecord>> GetAccidentRecords(string title, DateTime? date, string carNum)
        {
            return await _accident.GetAccidentRecords(title, date, carNum);
        }
    }
}
