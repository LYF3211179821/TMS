using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;
using TMS_Logistics.IRepository;

namespace TMS.Service.VehicleService.Maintain
{
    public class UpkeepRecordsService: IUpkeepRecordsService
    {
        private readonly IUpkeepRecordsRepository _upkeep;

        public UpkeepRecordsService(IUpkeepRecordsRepository upkeep)
        {
            _upkeep = upkeep;
        }


        public int UpkeepRecordsAdd(UpkeepRecord obj)
        {
            return _upkeep.UpkeepRecordsAdd(obj);
        }

        public int UpkeepRecordsDel(string UpkeepRecordID)
        {
            return _upkeep.UpkeepRecordsDel(UpkeepRecordID);
        }

        public UpkeepRecord UpkeepRecordsDetails(int UpkeepRecordID)
        {
            return _upkeep.UpkeepRecordsDetails(UpkeepRecordID);
        }

        public List<UpkeepRecord> UpkeepRecordsList(string UpkeepRecordName, string UpkeepRecordNowTime, string LicensePlateNumber)
        {
            return _upkeep.UpkeepRecordsList(UpkeepRecordName, UpkeepRecordNowTime, LicensePlateNumber);
        }

        public int UpkeepRecordsUpd(UpkeepRecord obj)
        {
            return _upkeep.UpkeepRecordsUpd(obj);
        }
    }
}
