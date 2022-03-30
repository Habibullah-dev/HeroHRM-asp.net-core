using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IResignRepository
    {
        Task<int> CreateResign(ResignModel model);
        Task DeleteResign(int id);
        Task<ResignModel> FindResigns(int id);
        Task<List<ResignModel>> GetResigns();
        Task UpdateHResign(ResignModel model);
    }
}