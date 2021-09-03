using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.VehicleService;
using TMS.Model.Entity.Entity.Vindicate;

namespace TMS.Service.VehicleService.Violation
{
    public class BreakRulesRecordService : IBreakRulesRecordService
    {
        private readonly IBreakRulesRecordRepository _breakRules;

        public BreakRulesRecordService(IBreakRulesRecordRepository breakRules)
        {
            _breakRules = breakRules;
        }


        public async Task<List<BreakRulesRecord>> GetBreakRules()
        {
            return await _breakRules.GetBreakRules();
        }
    }
}
