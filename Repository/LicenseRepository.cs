using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly HeroHRMContext _context = null;
        public LicenseRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLicense(LicenseModel model)
        {
            var newLicense = new License()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Licenses.AddAsync(newLicense);
            await _context.SaveChangesAsync();

            return newLicense.Id;

        }

        public async Task<List<LicenseModel>> GetLicense()
        {
            return await _context.Licenses
                 .Select(x => new LicenseModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteLicense(int id)
        {
            var foundLicense = await _context.Licenses.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundLicense != null)
            {
                _context.Remove(foundLicense);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<LicenseModel> FindLicense(int id)
        {
            return await _context.Licenses
                 .Where(x => x.Id == id)
                 .Select(x => new LicenseModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateLicense(LicenseModel model)
        {
            var updatedLicense = await _context.Licenses.FindAsync(model.Id);

            updatedLicense.Name = model.Name;
            updatedLicense.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
