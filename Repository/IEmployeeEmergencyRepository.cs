using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeEmergencyRepository
    {
        Task<int> CreateEmployeeEmergency(EmployeeEmergencyModel model);
        Task DeleteEmployeeEmergency(int id);
        Task<EmployeeEmergencyModel> FindEmployeeEmergency(int id);
        Task UpdateEmployeeEmergency(EmployeeEmergencyModel model);
        Task<List<EmployeeEmergencyModel>> FindEmployeeEmergencyByEmployeeID(int id);
    }
}