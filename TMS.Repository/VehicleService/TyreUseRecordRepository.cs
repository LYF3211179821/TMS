using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.VehicleService;
using TMS.Model.Entity.Vindicate;

namespace TMS.Repository.VehicleService
{
    public class TyreUseRecordRepository: ITyreUseRecordRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public TyreUseRecordRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 轮胎记录
        /// </summary>
        /// <returns></returns>
        public async Task<List<TyreUseRecord>> GetTyres()
        {
            string sql = "select * from TyreUseRecord";
            List<TyreUseRecord> data = await _SqlDB.QueryAsync<TyreUseRecord>(sql);
            return data;
        }

    }
}
