using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeLanguageRepository
    {
        Task<int> CreateEmployeeLanguage(EmployeeLanguageModel model);
        Task DeleteEmployeeLanguage(int id);
        Task<EmployeeLanguageModel> FindEmployeeLanguage(int id);
        Task UpdateEmployeeLanguage(EmployeeLanguageModel model);
        Task<EmployeeLanguageModel> FindByEmployeeId(int id);
    }
}