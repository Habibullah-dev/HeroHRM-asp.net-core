using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly HeroHRMContext _context = null;
        public CompanyInfoRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCompanyInfo(CompanyInfoModel model)
        {
            var newInfo = new CompanyInfo()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                TaxId = model.TaxId,
                EmployeeNumbers = model.EmployeeNumbers,
                RegistrationNumber = model.RegistrationNumber,
                UpdatedDate = DateTime.UtcNow,
                Phone = model.Phone,
                Fax = model.Fax,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Country = model.Country
            };

            await _context.CompanyInfos.AddAsync(newInfo);
            await _context.SaveChangesAsync();

            return newInfo.Id;

        }

        public async Task<List<CompanyInfoModel>> GetCompanyInfo()
        {
            return await _context.CompanyInfos
                 .Select(x => new CompanyInfoModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     TaxId = x.TaxId,
                     EmployeeNumbers = x.EmployeeNumbers,
                     RegistrationNumber = x.RegistrationNumber,
                     Phone = x.Phone,
                     Email = x.Email,
                     Address = x.Address,
                     Fax = x.Fax,
                     City = x.City,
                     State = x.State,
                     ZipCode = x.ZipCode,
                     Country = x.Country,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteCompanyInfo(int id)
        {
            var foundInfo = await _context.CompanyInfos.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundInfo != null)
            {
                _context.Remove(foundInfo);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<CompanyInfoModel> FindCompanyInfo(int id)
        {
            return await _context.CompanyInfos
                 .Where(x => x.Id == id)
                 .Select(x => new CompanyInfoModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     TaxId = x.TaxId,
                     EmployeeNumbers = x.EmployeeNumbers,
                     RegistrationNumber = x.RegistrationNumber,
                     Phone = x.Phone,
                     Email = x.Email,
                     Address = x.Address,
                     City = x.City,
                     Fax = x.Fax,
                     State = x.State,
                     ZipCode = x.ZipCode,
                     Country = x.Country,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateCompanyInfo(CompanyInfoModel model)
        {
            var updatedCompanyInfo = await _context.CompanyInfos.FindAsync(model.Id);

            updatedCompanyInfo.Name = model.Name;
            updatedCompanyInfo.TaxId = model.TaxId;
            updatedCompanyInfo.EmployeeNumbers = model.EmployeeNumbers;
            updatedCompanyInfo.RegistrationNumber = model.RegistrationNumber;
            updatedCompanyInfo.Phone = model.Phone;
            updatedCompanyInfo.Email = model.Email;
            updatedCompanyInfo.Address = model.Address;
            updatedCompanyInfo.City = model.City;
            updatedCompanyInfo.State = model.State;
            updatedCompanyInfo.ZipCode = model.ZipCode;
            updatedCompanyInfo.Country = model.Country;
            updatedCompanyInfo.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
