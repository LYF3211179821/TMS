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

        public int UpkeepRecordsAdd(UpkeepRecord obj)
        {
            string sql = $"insert into UpkeepRecord values('{obj.UpkeepRecordTitle}','{obj.LicensePlateNumber}','{obj.UpkeepRecordPrice}','{obj.UpkeepRecordName}','{obj.NowMileage}','{obj.LastMileage}','{obj.UpkeepRecordContent}','{obj.UpkeepRecordNowTime}','{obj.UpkeepRecordLastTime}','{obj.Remark}','{obj.CreateTime}','{obj.UpkeepRecordStatus}')";

            return _SqlDB.Execute(sql,null);
        }

        public int UpkeepRecordsDel(string UpkeepRecordID)
        {
            string sql = $"delete from UpkeepRecord where UpkeepRecordID in({UpkeepRecordID.Trim(',')})";

            return _SqlDB.Execute(sql, null);
        }

        public UpkeepRecord UpkeepRecordsDetails(int UpkeepRecordID)
        {
            string sql = $"select * from UpkeepRecord where UpkeepRecordID={UpkeepRecordID}";

            return _SqlDB.QueryFirst<UpkeepRecord>(sql,null);
        }

        public List<UpkeepRecord> UpkeepRecordsList(string UpkeepRecordName, string UpkeepRecordNowTime, string LicensePlateNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UpkeepRecordName", UpkeepRecordName);
            parameters.Add("UpkeepRecordNowTime", UpkeepRecordNowTime);
            parameters.Add("LicensePlateNumber", LicensePlateNumber);


            string sql = $"select * from UpkeepRecord where UpkeepRecordName like concat('%',@UpkeepRecordName,'%') and UpkeepRecordNowTime like concat('%',@UpkeepRecordNowTime,'%') and LicensePlateNumber like concat('%',@LicensePlateNumber,'%')";


            return _SqlDB.Query<UpkeepRecord>(sql, parameters);
        }

        public int UpkeepRecordsUpd(UpkeepRecord obj)
        {
            string sql = $"update UpkeepRecord set   UpkeepRecordTitle='{obj.UpkeepRecordTitle}',LicensePlateNumber='{obj.LicensePlateNumber}',UpkeepRecordPrice='{obj.UpkeepRecordPrice}',UpkeepRecordName='{obj.UpkeepRecordName}',NowMileage='{obj.NowMileage}',LastMileage='{obj.LastMileage}',UpkeepRecordContent='{obj.UpkeepRecordContent}',UpkeepRecordNowTime='{obj.UpkeepRecordNowTime}',UpkeepRecordLastTime='{obj.UpkeepRecordLastTime}',Remark='{obj.Remark}',CreateTime='{obj.CreateTime}',UpkeepRecordStatus='{obj.UpkeepRecordStatus}'  where UpkeepRecordID={obj.UpkeepRecordId}";

            return _SqlDB.Execute(sql,null);
        }
    }
}
