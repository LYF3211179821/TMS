using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;
using TMS.IRepository.VehicleService;

namespace TMS.Service.VehicleService.Repair
{
    public class MaintainRecordService: IMaintainRecordService
    {
        private readonly IMaintainRecordRepository _maintain;

        public MaintainRecordService(IMaintainRecordRepository maintain)
        {
            _maintain = maintain;
        }


        /// <summary>
        /// 显示维修记录
        /// </summary>
        /// <returns></returns>
        public async Task<List<MaintainRecord>> GetMaintainRecords()
        {
            return await _maintain.GetMaintainRecords();
        }


    }
}
