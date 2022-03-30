using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ICompanyInfoRepository
    {
        Task<int> CreateCompanyInfo(CompanyInfoModel model);
        Task DeleteCompanyInfo(int id);
        Task<CompanyInfoModel> FindCompanyInfo(int id);
        Task<List<CompanyInfoModel>> GetCompanyInfo();
        Task UpdateCompanyInfo(CompanyInfoModel model);
    }
}