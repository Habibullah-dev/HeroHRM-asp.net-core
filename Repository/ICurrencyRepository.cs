using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ICurrencyRepository
    {
        Task<int> CreateCurrency(CurrencyModel model);
        Task DeleteCurrency(int id);
        Task<CurrencyModel> FindCurrency(int id);
        Task<List<CurrencyModel>> GetCurrency();
        Task UpdateCurrency(CurrencyModel model);
    }
}