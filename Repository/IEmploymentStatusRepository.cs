using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmploymentStatusRepository
    {
        Task<int> CreateEmploymentStatus(EmploymentStatusModel model);
        Task DeleteEmploymentStatus(int id);
        Task<EmploymentStatusModel> FindEmploymentStatus(int id);
        Task<List<EmploymentStatusModel>> GetEmploymentStatus();
        Task UpdateEmploymentStatus(EmploymentStatusModel model);
    }
}