using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> CreateEmployee(EmployeeModel model);
        Task DeleteEmployee(int id);
        Task<EmployeeModel> FindEmployee(int id);
        Task UpdateEmployee(EmployeeModel model);
        Task<List<EmployeeModel>> GetEmployee();
        Task<EmployeeModel> FindEmployeeByuserID(string id);
    }

}