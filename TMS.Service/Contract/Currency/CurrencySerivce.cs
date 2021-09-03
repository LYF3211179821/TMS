using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Contract;
using TMS.Model.Entity.Contract;

namespace TMS.Service.Contract.Currency
{
    public class CurrencySerivce: ICurrencySerivce
    {
        private readonly ICurrencyRepository _currency;

        public CurrencySerivce(ICurrencyRepository currency)
        {
            _currency = currency;
        }

        /// <summary>
        /// 通用合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<CommonContract>> GetCommons()
        {
            return await _currency.GetCommons();
        }
    }
}
