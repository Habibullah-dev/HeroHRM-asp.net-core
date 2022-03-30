using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeWorkExperienceRepository
    {
        Task<int> CreateWorkExperienceModel(EmployeeWorkExperienceModel model);
        Task DeleteEmployeeWorkExperience(int id);
        Task<EmployeeWorkExperienceModel> FindEmployeeWorkExperience(int id);
        Task UpdateEmployeeWorkExperience(EmployeeWorkExperienceModel model);
        Task<EmployeeWorkExperienceModel> FindByEmployeeID(int id);
    }
}