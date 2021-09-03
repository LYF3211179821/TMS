using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TMS.Common.DB;
using TMS.Model.Entity.Vindicate;
using TMS_Logistics.IRepository;

namespace TMS_Logistics.Repository
{
    /// <summary>
    /// 保养记录
    /// </summary>
    public class UpkeepRecordsRepository : IUpkeepRecordsRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public UpkeepRecordsRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 保养记录显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<UpkeepRecord>> GetUpkeepRecords()
        {
            string sql = "select * from UpkeepRecord";
            List<UpkeepRecord> data = await _SqlDB.QueryAsync<UpkeepRecord>(sql);
            return data;
        } 
    }
}
