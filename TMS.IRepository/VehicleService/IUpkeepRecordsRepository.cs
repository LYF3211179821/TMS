using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Vindicate;
namespace TMS_Logistics.IRepository
{
    /// <summary>
    /// 保养记录
    /// </summary>
    public interface IUpkeepRecordsRepository
    {
        /// <summary>
        /// 保养记录显示
        /// </summary>
        /// <returns></returns>
        Task<List<UpkeepRecord>> GetUpkeepRecords();
    }
}
