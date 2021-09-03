using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Vindicate;

namespace TMS.Service.VehicleService.Cost
{
    public interface ICostRecordService
    {
        /// <summary>
        /// 费用记录显示
        /// </summary>
        /// <returns></returns>
        Task<List<CostRecord>> GetCosts();
    }
}
