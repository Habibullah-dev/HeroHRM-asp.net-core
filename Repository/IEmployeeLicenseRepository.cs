using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeLicenseRepository
    {
        Task<int> CreateEmployeeLicense(EmployeeLicenseModel model);
        Task DeleteEmployeeLicense(int id);
        Task<EmployeeLicenseModel> FindEmployeeLicense(int id);
        Task UpdateEmployeeLicense(EmployeeLicenseModel model);
        Task<EmployeeLicenseModel> FindByEmployeeId(int id);
    }
}