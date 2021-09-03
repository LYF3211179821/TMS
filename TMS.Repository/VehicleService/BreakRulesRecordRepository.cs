using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.VehicleService;
using TMS.Model.Entity.Entity.Vindicate;

namespace TMS.Repository.VehicleService
{
    public class BreakRulesRecordRepository: IBreakRulesRecordRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public BreakRulesRecordRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 违章记录显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<BreakRulesRecord>> GetBreakRules()
        {
            string sql = "select * from BreakRulesRecord";
            List<BreakRulesRecord> data = await _SqlDB.QueryAsync<BreakRulesRecord>(sql);
            return data;
        }

    }
}
