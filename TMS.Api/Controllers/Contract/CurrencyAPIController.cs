using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Service.Contract.Currency;

namespace TMS.Api.Controllers.Contract
{
    /// <summary>
    /// 合同管理-通用合同
    /// </summary>
    [Route("CurrencyAPI")]
    [ApiController]
    public class CurrencyAPIController : ControllerBase
    {
        private readonly ICurrencySerivce _currency;

        public CurrencyAPIController(ICurrencySerivce currency)
        {
            _currency = currency;
        }

        /// <summary>
        /// 通用合同显示
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCommons")]
        public async Task<IActionResult> GetCommons()
        {
            return Ok(await _currency.GetCommons());
        }

    }
}
