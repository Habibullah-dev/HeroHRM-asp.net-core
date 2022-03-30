using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ILicenseRepository
    {
        Task<int> CreateLicense(LicenseModel model);
        Task DeleteLicense(int id);
        Task<LicenseModel> FindLicense(int id);
        Task<List<LicenseModel>> GetLicense();
        Task UpdateLicense(LicenseModel model);
    }
}