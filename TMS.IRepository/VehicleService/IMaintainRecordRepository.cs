using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;

namespace TMS.IRepository.VehicleService
{
    public interface IMaintainRecordRepository
    {
        /// <summary>
        /// 显示维修记录
        /// </summary>
        /// <returns></returns>
        Task<List<MaintainRecord>> GetMaintainRecords();
    }
}
