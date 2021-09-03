using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.VehicleService;
using TMS.Model.Entity.Vindicate;

namespace TMS.Service.VehicleService.Tyre
{
    public class TyreUseRecordService: ITyreUseRecordService
    {
        private readonly ITyreUseRecordRepository _tyre;

        public TyreUseRecordService(ITyreUseRecordRepository tyre)
        {
            _tyre = tyre;
        }


        /// <summary>
        /// 轮胎记录
        /// </summary>
        /// <returns></returns>
        public async Task<List<TyreUseRecord>> GetTyres()
        {
            return await _tyre.GetTyres();
        }

    }
}
