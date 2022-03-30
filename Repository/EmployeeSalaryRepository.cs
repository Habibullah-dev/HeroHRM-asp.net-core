using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeSalaryRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeSalary(EmployeeSalaryModel model)
        {
            var newEmployeeSalary = new EmployeeSalary()
            {
                PayGradeId = model.PayGradeId,
                PayFrequency = model.PayFrequency,
                CuurencyId = model.CuurencyId,
                Amount = model.Amount,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeSalaries.AddAsync(newEmployeeSalary);
            await _context.SaveChangesAsync();

            return newEmployeeSalary.Id;
        }

        public async Task DeleteEmployeeSalary(int id)
        {
            var foundEmployeeSalary = await _context.EmployeeSalaries.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeSalary != null)
            {
                _context.Remove(foundEmployeeSalary);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeSalaryModel> FindEmployeeSalary(int id)
        {
            return await _context.EmployeeSalaries
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeSalaryModel()
                 {
                     Id = x.Id,
                     PayGradeId = x.PayGradeId,
                     PayGrade = x.PayGrades.Name,
                     PayFrequency = x.PayFrequency,
                     Currency = x.Currency.Name,
                     CuurencyId = x.CuurencyId,
                     Amount = x.Amount,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeSalaryModel> FindByEmployeeID(int id)
        {
            return await _context.EmployeeSalaries
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeSalaryModel()
                 {
                     Id = x.Id,
                     PayGradeId = x.PayGradeId,
                     PayGrade = x.PayGrades.Name,
                     PayFrequency = x.PayFrequency,
                     CuurencyId = x.CuurencyId,
                     Currency = x.Currency.Name,
                     Amount = x.Amount,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeSalary(EmployeeSalaryModel model)
        {
            var updated = await _context.EmployeeSalaries.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.PayGradeId = model.PayGradeId;
            updated.PayFrequency = model.PayFrequency;
            updated.CuurencyId = model.CuurencyId;
            updated.Amount = model.Amount;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
