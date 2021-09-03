using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.Contract;
using TMS.Model.Entity.Contract;

namespace TMS.Repository.Contract
{
    public class CurrencyRepository: ICurrencyRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public CurrencyRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 通用合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<CommonContract>> GetCommons()
        {
            string sql = "select CommonContractNo,CommonContractTitle,CommonContractUnit,OwnerOfCargoContractName,CommonContractType,CommonContractCircuit,TonRunPrice,CharteredBusConditionTonNum,CharteredBusPrice,DateOfSigningTime,CircuitResponsibleName,CreateTime,CommonContractStatus,CommonContractName from CommonContract";
            List<CommonContract> data = await _SqlDB.QueryAsync<CommonContract>(sql);
            return data;
        }

    }
}
