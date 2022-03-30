using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeSubordinateRepository : IEmployeeSubordinateRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeSubordinateRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeSubordinate(EmployeeSubordinateModel model)
        {
            var newEmployeeSubordinate = new EmployeeSubordinate()
            {
                Subordinate = model.Subordinate,
                ReportingMethod = model.ReportingMethod,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeSubordinates.AddAsync(newEmployeeSubordinate);
            await _context.SaveChangesAsync();

            return newEmployeeSubordinate.Id;
        }

        public async Task DeleteEmployeeSubordinate(int id)
        {
            var foundEmployeeSubordinate = await _context.EmployeeSubordinates.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (foundEmployeeSubordinate != null)
            {
                _context.Remove(foundEmployeeSubordinate);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeSubordinateModel> FindEmployeeSubordinate(int id)
        {
            return await _context.EmployeeSubordinates
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeSubordinateModel()
                 {
                     Id = x.Id,
                     Subordinate = x.Subordinate,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeSubordinateModel> FindEmployeeeID(int id)
        {
            return await _context.EmployeeSubordinates
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeSubordinateModel()
                 {
                     Id = x.Id,
                     Subordinate = x.Subordinate,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }



        public async Task UpdateEmployeeSubordinate(EmployeeSubordinateModel model)
        {
            var updated = await _context.EmployeeSubordinates.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.Subordinate = model.Subordinate;
            updated.ReportingMethod = model.ReportingMethod;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
