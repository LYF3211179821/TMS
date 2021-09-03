using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.Service.Contract.Currency
{
    public interface ICurrencySerivce
    {
        /// <summary>
        /// 通用合同显示
        /// </summary>
        /// <returns></returns>
        Task<List<CommonContract>> GetCommons();
    }
}
