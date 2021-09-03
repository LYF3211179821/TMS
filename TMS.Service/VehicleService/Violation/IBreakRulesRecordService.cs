using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Entity.Vindicate;

namespace TMS.Service.VehicleService.Violation
{
    public interface IBreakRulesRecordService
    {
        /// <summary>
        /// 违章记录显示
        /// </summary>
        /// <returns></returns>
        Task<List<BreakRulesRecord>> GetBreakRules();
    }
}
