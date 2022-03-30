using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeJobRepository
    {
        Task<int> CreateEmployeeJob(EmployeeJobModel model);
        Task DeleteEmployeeJob(int id);
        Task<EmployeeJobModel> FindEmployeeJob(int id);
        Task UpdateEmployeeJob(EmployeeJobModel model);
        Task<EmployeeJobModel> FindByEmployeeId(int id);
    }
}