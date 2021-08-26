using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;
using TMS.Common.DB;
using TMS.IRepository.Personnel;
using TMS.Model.Entity;
using TMS.Model.Entity.Personnel;

namespace TMS.Repository.Personnel
{
    public class EmployeeregistrationRepository : IEmployeeregistrationRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public EmployeeregistrationRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
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
        public async Task<List<EmployeeRegistration>> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType)
        {
            string sql = "select a.EmployeeId,a.EmployeeName,a.EmployeeSex,b.DepartmentName,c.PositionName,a.EmployeePhone,d.UserSchool,d.UseMajor,d.UserHomePlace,a.EmployeeEntryTime,a.EmployeeType,b.DepartmentStatus,a.CreateTime from EmployeeModel a join DepartmentModel b on a.EmployeeID = b.DepartmentID join PositionModel c on a.EmployeeID = c.PositionID join UserModel d on a.EmployeeID = d.UserID";
            List<EmployeeRegistration> data = await _SqlDB.QueryAsync<EmployeeRegistration>(sql);
            //查询
            if (!string.IsNullOrEmpty(EmpName))
            {
                data = data.Where(m => m.EmployeeName.Contains(EmpName)).ToList();
            }
            if (EmpDeparName != 0)
            {
                data = data.Where(m => m.DepartmentName.Contains((char)EmpDeparName)).ToList();
            }
            if (PosterName != 0)
            {
                data = data.Where(m => m.PositionName.Contains((char)PosterName)).ToList();
            }
            if (!string.IsNullOrEmpty(EmpPhone))
            {
                data = data.Where(m => m.EmployeePhone.Contains(EmpPhone)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<bool> AddEmployee(EmployeeModel model)
        {
            string sql = "insert into EmployeeModel values(@EmployeeName,@EmployeeSex,@EmployeePhone,@EmployeeType,@EmployeeEntryTime,@EmployeeEndWorkTime,@EmployeeLeaveSession,@EmployeeProposerTime,@EmployeeParentName,@CreateTime,@EmployeeStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @EmployeeName = model.EmployeeName,
                @EmployeeSex = model.EmployeeSex,
                @EmployeePhone = model.EmployeePhone,
                @EmployeeType = model.EmployeeType,
                @EmployeeEntryTime = model.EmployeeEntryTime,
                @EmployeeEndWorkTime = model.EmployeeEndWorkTime,
                @EmployeeLeaveSession = model.EmployeeLeaveSession,
                @EmployeeProposerTime = model.EmployeeProposerTime,
                @EmployeeParentName = model.EmployeeParentName,
                @CreateTime = DateTime.Now,
                @EmployeeStatus = 1
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 人事模块—员工登记—删除（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelEmployee(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "update EmployeeModel set EmployeeStatus=0 where EmployeeID in (@ID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 人事模块—员工登记—反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeModel> EditEmployee(int id)
        {
            string sql = "select * from EmployeeModel where EmployeeID=@ID";
            return await _SqlDB.QueryFirstAsync<EmployeeModel>(sql, new { @ID = id });
        }

        /// <summary>
        /// 人事模块—员工登记—修改
        /// </summary>
        /// <param name="employeeRegistration"></param>
        /// <returns></returns>
        public async Task<bool> UpdEmployee(EmployeeModel model)
        {
            string sql = "update EmployeeModel set EmployeeName=@EmployeeName,EmployeeSex=@EmployeeSex,EmployeePhone=@EmployeePhone,EmployeeType=@EmployeeType,EmployeeEntryTime=@EmployeeEntryTime,EmployeeEndWorkTime=@EmployeeEndWorkTime,EmployeeLeaveSession=@EmployeeLeaveSession,EmployeeProposerTime=@EmployeeProposerTime,EmployeeParentName=@EmployeeParentName,CreateTime=@CreateTime,EmployeeStatus=@EmployeeStatus   where EmployeeID=@EmployeeID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @EmployeeID = model.EmployeeId,
                @EmployeeName = model.EmployeeName,
                @EmployeeSex = model.EmployeeSex,
                @EmployeePhone = model.EmployeePhone,
                @EmployeeType = model.EmployeeType,
                @EmployeeEntryTime = model.EmployeeEntryTime,
                @EmployeeEndWorkTime = model.EmployeeEndWorkTime,
                @EmployeeLeaveSession = model.EmployeeLeaveSession,
                @EmployeeProposerTime = model.EmployeeProposerTime,
                @EmployeeParentName = model.EmployeeParentName,
                @CreateTime = DateTime.Now,
                @EmployeeStatus = 1
            });
            return code == 0 ? true : false;
        }
    }
}
