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
    public class AccidentRecordRepository: IAccidentRecordRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public AccidentRecordRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 显示事故记录
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="carNum"></param>
        /// <returns></returns>
        public async Task<List<AccidentRecord>> GetAccidentRecords(string title, DateTime? date, string carNum)
        {
            string sql = "select * from AccidentRecord";
            List<AccidentRecord> data = await _SqlDB.QueryAsync<AccidentRecord>(sql);
            if (!string.IsNullOrEmpty(title))
            {
                data = data.Where(x => x.AccidentTitle.Contains(title)).ToList();
            }
            if (date != null)
            {
                data = data.Where(x => x.AccidentTime.Value.ToString("yyyy-MM-dd") == date.Value.ToString("dd")).ToList();
            }
            if (!string.IsNullOrEmpty(carNum))
            {
                data = data.Where(x => x.LicensePlateNumber.Contains(carNum)).ToList();
            }
            return data;
        }

    }
}
