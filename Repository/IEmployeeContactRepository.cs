using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeContactRepository
    {
        Task<int> CreateEmployeeContact(EmployeeContactModel model);
        Task DeleteEmployeeContact(int id);
        Task<EmployeeContactModel> FindEmployeeContact(int id);
        Task UpdateEmployeeContact(EmployeeContactModel model);
        Task<EmployeeContactModel> FindEmployeeContactByEmployeeId(int employee_id);
    }
}