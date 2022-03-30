using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeEducationRepository
    {
        Task<int> CreateEmployeeEducation(EmployeeEducationModel model);
        Task DeleteEmployeeEducation(int id);
        Task<EmployeeEducationModel> FindEmployeeEducation(int id);
        Task UpdateEmployeeEducation(EmployeeEducationModel model);
        Task<EmployeeEducationModel> FindByEmployeeId(int id);
    }
}