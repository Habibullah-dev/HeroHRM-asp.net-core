using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeSalaryRepository
    {
        Task<int> CreateEmployeeSalary(EmployeeSalaryModel model);
        Task DeleteEmployeeSalary(int id);
        Task<EmployeeSalaryModel> FindEmployeeSalary(int id);
        Task UpdateEmployeeSalary(EmployeeSalaryModel model);
        Task<EmployeeSalaryModel> FindByEmployeeID(int id);
    }
}