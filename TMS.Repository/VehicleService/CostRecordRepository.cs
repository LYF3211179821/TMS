using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.VehicleService;
using TMS.Model.Vindicate;

namespace TMS.Repository.VehicleService
{
    public class CostRecordRepository: ICostRecordRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public CostRecordRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 费用记录显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<CostRecord>> GetCosts()
        {
            string sql = "select * from CostRecord";
            List<CostRecord> data = await _SqlDB.QueryAsync<CostRecord>(sql);
            return data;
        }


    }
}
