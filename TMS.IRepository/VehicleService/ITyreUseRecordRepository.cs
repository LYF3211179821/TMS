using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;

namespace TMS.IRepository.VehicleService
{
    public interface ITyreUseRecordRepository
    {
        /// <summary>
        /// 轮胎记录
        /// </summary>
        /// <returns></returns>
        Task<List<TyreUseRecord>> GetTyres();
    }
}
