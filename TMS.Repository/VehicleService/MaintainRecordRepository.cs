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
    public class MaintainRecordRepository: IMaintainRecordRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public MaintainRecordRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 显示维修记录
        /// </summary>
        /// <returns></returns>
        public async Task<List<MaintainRecord>> GetMaintainRecords()
        {
            string sql = "select * from MaintainRecord";
            List<MaintainRecord> data = await _SqlDB.QueryAsync<MaintainRecord>(sql);
            return data;
        }

    }
}
