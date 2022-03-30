using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HeroHRMContext _context = null;
        public DepartmentRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateDepartment(DepartmentModel model)
        {
            var newDepartment = new Department()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();

            return newDepartment.Id;

        }

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            return await _context.Departments
                 .Select(x => new DepartmentModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteDepartment(int id)
        {
            var foundDepartment = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundDepartment != null)
            {
                _context.Remove(foundDepartment);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<DepartmentModel> FindDepartment(int id)
        {
            return await _context.Departments
                 .Where(x => x.Id == id)
                 .Select(x => new DepartmentModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateDepartment(DepartmentModel model)
        {
            var updatedDepartment = await _context.Departments.FindAsync(model.Id);

            updatedDepartment.Name = model.Name;
            updatedDepartment.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
