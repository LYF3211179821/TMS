using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;
using TMS.Model.Entity.Personnel;
using TMS.Model.ViewModel;

namespace TMS.Service.Personnel
{
    public interface IEmployeeregistrationService
    {
        /// <summary>
        /// 人事模块—员工登记—显示接口
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EmpPhone"></param>
        /// <param name="EmpType"></param>
        /// <returns></returns>
        Task<List<EmployeeRegistration>> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType);


        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddEmployee(EmployeeModel model);

        /// <summary>
        /// 人事模块—员工登记—删除（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelEmployee(string id);

        /// <summary>
        /// 人事模块—员工登记—反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeModel> EditEmployee(int id);

        /// <summary>
        /// 人事模块—员工登记—修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdEmployee(EmployeeModel model);
    }
}
