using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.VehicleService;
using TMS.Model.Vindicate;

namespace TMS.Service.VehicleService.Cost
{
    public class CostRecordService: ICostRecordService
    {
        private readonly ICostRecordRepository _cost;

        public CostRecordService(ICostRecordRepository cost)
        {
            _cost = cost;
        }


        /// <summary>
        /// 费用记录显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<CostRecord>> GetCosts()
        {
            return await _cost.GetCosts();
        }

    }
}
