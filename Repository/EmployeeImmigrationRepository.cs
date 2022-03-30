using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeImmigrationRepository : IEmployeeImmigrationRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeImmigrationRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeImmigration(EmployeeImmigrationModel model)
        {
            var newEmployeeImmigration = new EmployeeImmigration()
            {
                DocumentType = model.DocumentType,
                Number = model.Number,
                IssuedDate = model.IssuedDate,
                ExpiryDate = model.ExpiryDate,
                EligibleStatus = model.EligibleStatus,
                EligibleReviewDate = model.EligibleReviewDate,
                IssuedBy = model.IssuedBy,
                NationalityId = model.IssuedBy,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeImmigrations.AddAsync(newEmployeeImmigration);
            await _context.SaveChangesAsync();

            return newEmployeeImmigration.Id;

        }


        public async Task DeleteEmployeeImmigration(int id)
        {
            var foundEmployeeImmigration = await _context.EmployeeImmigrations.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeImmigration != null)
            {
                _context.Remove(foundEmployeeImmigration);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeImmigrationModel> FindEmployeeImmigration(int id)
        {
            return await _context.EmployeeImmigrations
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeImmigrationModel()
                 {
                     Id = x.Id,
                     DocumentType = x.DocumentType,
                     IssuedDate = x.IssuedDate,
                     ExpiryDate = x.ExpiryDate,
                     Number = x.Number,
                     EligibleStatus = x.EligibleStatus,
                     IssuedBy = x.IssuedBy,
                     EligibleReviewDate = x.EligibleReviewDate,
                     EmployeeId = x.EmployeeId,
                     Country = x.Nationality.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeImmigrationModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeImmigrations
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeImmigrationModel()
                 {
                     Id = x.Id,
                     DocumentType = x.DocumentType,
                     IssuedDate = x.IssuedDate,
                     ExpiryDate = x.ExpiryDate,
                     Number = x.Number,
                     Country = x.Nationality.Name,
                     EligibleStatus = x.EligibleStatus,
                     IssuedBy = x.IssuedBy,
                     EligibleReviewDate = x.EligibleReviewDate,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeImmigration(EmployeeImmigrationModel model)
        {
            var updated = await _context.EmployeeImmigrations.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.DocumentType = model.DocumentType;
            updated.IssuedDate = model.IssuedDate;
            updated.ExpiryDate = model.ExpiryDate;
            updated.Number = model.Number;
            updated.EligibleReviewDate = model.EligibleReviewDate;
            updated.EligibleStatus = model.EligibleStatus;
            updated.IssuedBy = model.IssuedBy;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
