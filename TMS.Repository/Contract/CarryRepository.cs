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
    public class CarryRepository: ICarryRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public CarryRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 承运合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<AcceptContract>> GetAccepts()
        {
            string sql = "select AcceptContractNo,AcceptContractTitle,AcceptContractUnit,OwnerOfCargoContractName,AcceptContractCircuit,TonRunPrice,CharteredBusConditionTonNum,CharteredBusPrice,DateOfSigningTime,CircuitResponsibleName,CreateTime,AcceptContractStatus,CommonContractName from AcceptContract";
            List<AcceptContract> data = await _SqlDB.QueryAsync<AcceptContract>(sql);
            return data;
        }
    }
}
