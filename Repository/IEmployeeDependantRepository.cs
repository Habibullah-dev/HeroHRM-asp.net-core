using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeDependantRepository
    {
        Task<int> CreateEmployeeDependant(EmployeeDependantModel model);
        Task DeleteEmployeeDependant(int id);
        Task<EmployeeDependantModel> FindEmployeeDependant(int id);
        Task UpdateEmployeeDependant(EmployeeDependantModel model);
        Task<List<EmployeeDependantModel>> FindEmployeeDependantByEmployeeID(int id);
    }
}