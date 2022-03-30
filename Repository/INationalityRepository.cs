using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface INationalityRepository
    {
        Task<int> CreateNationality(NationalityModel model);
        Task DeleteNationality(int id);
        Task<NationalityModel> FindNationality(int id);
        Task<List<NationalityModel>> GetNationality();
        Task UpdateNationality(NationalityModel model);
    }
}