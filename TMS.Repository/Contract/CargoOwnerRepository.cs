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
    public class CargoOwnerRepository : ICargoOwnerRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public CargoOwnerRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 货主合同显示
        /// </summary>
        /// <returns></returns>
        public async Task<List<OwnerOfCargoContract>> GetCargoContracts()
        {
            string sql = "select OwnerOfCargoContractNo,OwnerOfCargoContractTitle,OwnerOfCargoContractUnit,OwnerOfCargoContractName,CommonContractCircuit,TonRunPrice,CharteredBusConditionTonNum,CharteredBusPrice,DateOfSigningTime,CircuitResponsibleName,CreateTime,CommonContractStatus,CommonContractName from OwnerOfCargoContract";
            List<OwnerOfCargoContract> data = await _SqlDB.QueryAsync<OwnerOfCargoContract>(sql);
            return data;
        }

    }
}
