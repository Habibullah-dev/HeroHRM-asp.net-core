using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeSupervisorRepository
    {
        Task<int> CreateEmployeeSupervisor(EmployeeSupervisorModel model);
        Task DeleteEmployeeSupervisor(int id);
        Task<EmployeeSupervisorModel> FindEmployeeSupervisor(int id);
        Task UpdateEmployeeSupervisor(EmployeeSupervisorModel model);
        Task<EmployeeSupervisorModel> FindByEmployeeId(int id);
    }
}