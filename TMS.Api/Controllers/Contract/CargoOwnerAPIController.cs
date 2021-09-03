using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.Contract.CargoOwner;

namespace TMS.Api.Controllers.Contract
{
    /// <summary>
    /// 合同管理-货主合同
    /// </summary>
    [Route("CargoOwnerAPI")]
    [ApiController]
    [ApiWrapResult]
    public class CargoOwnerAPIController : ControllerBase
    {
        private readonly ICargoOwnerService _cargoOwner;

        public CargoOwnerAPIController(ICargoOwnerService cargoOwner)
        {
            _cargoOwner = cargoOwner;
        }

        /// <summary>
        /// 货主合同显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCargoContracts")]
        public async Task<IActionResult> GetCargoContracts()
        {
            return Ok(await _cargoOwner.GetCargoContracts());
        }

    }
}
