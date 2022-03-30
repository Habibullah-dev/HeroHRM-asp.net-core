using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ILanguageRepository
    {
        Task<int> CreateLanguage(LanguageModel model);
        Task DeleteLanguage(int id);
        Task<LanguageModel> FindLanguage(int id);
        Task<List<LanguageModel>> GetLanguage();
        Task UpdateLanguage(LanguageModel model);
    }
}