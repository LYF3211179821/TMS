using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.IRepository.Contract
{
    public interface ICargoOwnerRepository
    {
        /// <summary>
        /// 货主合同显示
        /// </summary>
        /// <returns></returns>
        Task<List<OwnerOfCargoContract>> GetCargoContracts();

    }
}
