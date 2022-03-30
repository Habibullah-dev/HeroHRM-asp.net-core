using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEducationRepsoitory
    {
        Task<int> CreateEducation(EducationModel model);
        Task DeleteEducation(int id);
        Task<EducationModel> FindEducation(int id);
        Task<List<EducationModel>> GetEducation();
        Task UpdateEducation(EducationModel model);
    }
}