using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Contract;
using TMS.Model.Entity.Contract;

namespace TMS.Service.Contract.CargoOwner
{
    public class CargoOwnerService: ICargoOwnerService
    {
        private readonly ICargoOwnerRepository _cargoOwner;

        public CargoOwnerService(ICargoOwnerRepository cargoOwner)
        {
            _cargoOwner = cargoOwner;
        }


        /// <summary>
        /// 货主合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<OwnerOfCargoContract>> GetCargoContracts()
        {
            return await _cargoOwner.GetCargoContracts();
        }

    }
}
