using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ISkillRepository
    {
        Task<int> CreateSkill(SkillModel model);
        Task DeleteSkill(int id);
        Task<SkillModel> FindSkill(int id);
        Task<List<SkillModel>> GetSkill();
        Task UpdateSkill(SkillModel model);
    }
}