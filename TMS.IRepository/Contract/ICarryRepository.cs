using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.IRepository.Contract
{
    public interface ICarryRepository
    {

        /// <summary>
        /// 承运合同显示
        /// </summary>
        /// <returns></returns>
        Task<List<AcceptContract>> GetAccepts();
    }
}
