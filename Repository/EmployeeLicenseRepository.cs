using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeLicenseRepository : IEmployeeLicenseRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeLicenseRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeLicense(EmployeeLicenseModel model)
        {
            var newEmployeeLicense = new EmployeeLicense()
            {
                LicenseId = model.LicenseId,
                LicenseNumber = model.LicenseNumber,
                ExpiryDate = model.ExpiryDate,
                Comments = model.Comments,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeLicenses.AddAsync(newEmployeeLicense);
            await _context.SaveChangesAsync();

            return newEmployeeLicense.Id;

        }


        public async Task DeleteEmployeeLicense(int id)
        {
            var foundEmployeeLicense = await _context.EmployeeLicenses.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeLicense != null)
            {
                _context.Remove(foundEmployeeLicense);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeLicenseModel> FindEmployeeLicense(int id)
        {
            return await _context.EmployeeLicenses
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeLicenseModel()
                 {
                     Id = x.Id,
                     LicenseId = x.LicenseId,
                     LicenseNumber = x.LicenseNumber,
                     IssuedDate = x.IssuedDate,
                     ExpiryDate = x.ExpiryDate,
                     Comments = x.Comments,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeLicenseModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeLicenses
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeLicenseModel()
                 {
                     Id = x.Id,
                     LicenseId = x.LicenseId,
                     License =x.License.Name,
                     LicenseNumber = x.LicenseNumber,
                     IssuedDate = x.IssuedDate,
                     ExpiryDate = x.ExpiryDate,
                     Comments = x.Comments,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeLicense(EmployeeLicenseModel model)
        {
            var updated = await _context.EmployeeLicenses.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.LicenseId = model.LicenseId;
            updated.LicenseNumber = model.LicenseNumber;
            updated.IssuedDate = model.IssuedDate;
            updated.ExpiryDate = model.ExpiryDate;
            updated.Comments = model.Comments;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
