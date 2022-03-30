using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ICompanyBranchRepository
    {
        Task<int> CreateCompanyBranch(CompanyBranchModel model);
        Task DeleteCompanyBranch(int id);
        Task<CompanyBranchModel> FindCompanyBranch(int id);
        Task<List<CompanyBranchModel>> GetCompanyBranch();
        Task UpdateCompanyBranch(CompanyBranchModel model);
    }
}