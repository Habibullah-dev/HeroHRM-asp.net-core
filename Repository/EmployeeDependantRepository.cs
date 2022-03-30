using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeDependantRepository : IEmployeeDependantRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeDependantRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeDependant(EmployeeDependantModel model)
        {
            var newEmployeeDependant = new EmployeeDependant()
            {
                Name = model.Name,
                Relationship = model.Relationship,
                DateOfBirth = model.DateOfBirth,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeDependants.AddAsync(newEmployeeDependant);
            await _context.SaveChangesAsync();

            return newEmployeeDependant.Id;

        }


        public async Task DeleteEmployeeDependant(int id)
        {
            var foundEmployeeDependant = await _context.EmployeeDependants.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeDependant != null)
            {
                _context.Remove(foundEmployeeDependant);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeDependantModel> FindEmployeeDependant(int id)
        {
            return await _context.EmployeeDependants
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeDependantModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Relationship = x.Relationship,
                     DateOfBirth = x.DateOfBirth,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<List<EmployeeDependantModel>> FindEmployeeDependantByEmployeeID(int id)
        {
            return await _context.EmployeeDependants
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeDependantModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Relationship = x.Relationship,
                     DateOfBirth = x.DateOfBirth,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).ToListAsync();
        }

        public async Task UpdateEmployeeDependant(EmployeeDependantModel model)
        {
            var updatedEmployee = await _context.EmployeeDependants.FindAsync(model.Id);

            updatedEmployee.Id = model.Id;
            updatedEmployee.Name = model.Name;
            updatedEmployee.Relationship = model.Relationship;
            updatedEmployee.DateOfBirth = model.DateOfBirth;
            updatedEmployee.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
