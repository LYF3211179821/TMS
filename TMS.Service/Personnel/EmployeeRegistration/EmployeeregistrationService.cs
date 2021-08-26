using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.ViewModel;
using TMS.IRepository.Personnel;
using TMS.Model.Entity;
using TMS.Model.Entity.Personnel;

namespace TMS.Service.Personnel
{
    public class EmployeeregistrationService : IEmployeeregistrationService
    {
        public readonly IEmployeeregistrationRepository _employeeregistration;

        public EmployeeregistrationService(IEmployeeregistrationRepository employeeregistration)
        {
            _employeeregistration = employeeregistration;
        }

        /// <summary>
        /// 人事模块—员工登记—显示
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EmpPhone"></param>
        /// <param name="EmpType"></param>
        /// <returns></returns>
        public async Task< List<EmployeeRegistration>> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType)
        {
            return await _employeeregistration.GetEmployeeRegistrations(EmpName, EmpDeparName, PosterName, EmpPhone, EmpType);
        }

        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddEmployee(EmployeeModel model)
        {
            return await _employeeregistration.AddEmployee(model);
        }

        /// <summary>
        /// 人事模块—员工登记—删除（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelEmployee(string id)
        {
            return await _employeeregistration.DelEmployee(id);
        }

        /// <summary>
        /// 人事模块—员工登记—反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeModel> EditEmployee(int id)
        {
            return await _employeeregistration.EditEmployee(id);
        }

        /// <summary>
        /// 人事模块—员工登记—修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdEmployee(EmployeeModel model)
        {
            return await _employeeregistration.UpdEmployee(model);
        }
    }
}
