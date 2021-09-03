using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;

namespace TMS.Service.VehicleService.Tyre
{
    public interface ITyreUseRecordService
    {
        /// <summary>
        /// 轮胎记录
        /// </summary>
        /// <returns></returns>
        Task<List<TyreUseRecord>> GetTyres();
    }
}
