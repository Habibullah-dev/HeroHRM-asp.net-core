using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmploymentStatusRepository : IEmploymentStatusRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmploymentStatusRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmploymentStatus(EmploymentStatusModel model)
        {
            var newStatus = new EmploymentStatus()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.EmploymentStatuses.AddAsync(newStatus);
            await _context.SaveChangesAsync();

            return newStatus.Id;

        }

        public async Task<List<EmploymentStatusModel>> GetEmploymentStatus()
        {
            return await _context.EmploymentStatuses
                 .Select(x => new EmploymentStatusModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteEmploymentStatus(int id)
        {
            var foundStatus = await _context.EmploymentStatuses.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundStatus != null)
            {
                _context.Remove(foundStatus);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmploymentStatusModel> FindEmploymentStatus(int id)
        {
            return await _context.EmploymentStatuses
                 .Where(x => x.Id == id)
                 .Select(x => new EmploymentStatusModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmploymentStatus(EmploymentStatusModel model)
        {
            var updatedStatus = await _context.EmploymentStatuses.FindAsync(model.Id);

            updatedStatus.Name = model.Name;
            updatedStatus.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
