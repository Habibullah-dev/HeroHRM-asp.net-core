using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeSkillRepository
    {
        Task<int> CreateEmployeeSkill(EmployeeSkillModel model);
        Task DeleteEmployeeSkill(int id);
        Task<EmployeeSkillModel> FindEmployeeSkill(int id);
        Task UpdateEmployeeSkill(EmployeeSkillModel model);
        Task<EmployeeSkillModel> FindByEmployeeID(int id);
    }
}