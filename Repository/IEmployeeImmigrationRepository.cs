using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeImmigrationRepository
    {
        Task<int> CreateEmployeeImmigration(EmployeeImmigrationModel model);
        Task DeleteEmployeeImmigration(int id);
        Task<EmployeeImmigrationModel> FindEmployeeImmigration(int id);
        Task UpdateEmployeeImmigration(EmployeeImmigrationModel model);
        Task<EmployeeImmigrationModel> FindByEmployeeId(int id);
    }
}