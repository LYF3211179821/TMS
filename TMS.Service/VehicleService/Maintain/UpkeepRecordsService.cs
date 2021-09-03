using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;
using TMS_Logistics.IRepository;

namespace TMS.Service.VehicleService.Maintain
{
    public class UpkeepRecordsService: IUpkeepRecordsService
    {
        private readonly IUpkeepRecordsRepository _upkeep;

        public UpkeepRecordsService(IUpkeepRecordsRepository upkeep)
        {
            _upkeep = upkeep;
        }

        /// <summary>
        /// 保养记录显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<UpkeepRecord>> GetUpkeepRecords()
        {
            return await _upkeep.GetUpkeepRecords();
        }
    }
}
