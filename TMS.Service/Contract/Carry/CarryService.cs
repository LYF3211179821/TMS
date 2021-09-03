using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Contract;
using TMS.Model.Entity.Contract;

namespace TMS.Service.Contract.Carry
{
    public class CarryService: ICarryService
    {
        private readonly ICarryRepository _carry;

        public CarryService(ICarryRepository carry)
        {
            _carry = carry;
        }

        /// <summary>
        /// 承运合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<AcceptContract>> GetAccepts()
        {
            return await _carry.GetAccepts();
        }

    }
}
