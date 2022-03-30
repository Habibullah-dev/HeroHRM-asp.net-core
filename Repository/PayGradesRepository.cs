using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class PayGradesRepository : IPayGradesRepository
    {
        private readonly HeroHRMContext _context = null;
        public PayGradesRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreatePayGrade(PayGradesModel model)
        {
            var newPayGrade = new PayGrades()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                Currency = model.Currency,
                MinimumSalary = model.MinimumSalary,
                MaximumSalary = model.MaximumSalary,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.PayGrades.AddAsync(newPayGrade);
            await _context.SaveChangesAsync();

            return newPayGrade.Id;

        }

        public async Task<List<PayGradesModel>> GetPayGrades()
        {
            return await _context.PayGrades
                 .Select(x => new PayGradesModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Currency = x.Currency,
                     MinimumSalary = x.MinimumSalary,
                     MaximumSalary = x.MaximumSalary,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeletePayGrade(int id)
        {
            var foundPayGrade = await _context.PayGrades.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundPayGrade != null)
            {
                _context.Remove(foundPayGrade);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<PayGradesModel> FindPayGrade(int id)
        {
            return await _context.PayGrades
                 .Where(x => x.Id == id)
                 .Select(x => new PayGradesModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Currency = x.Currency,
                     MinimumSalary = x.MinimumSalary,
                     MaximumSalary = x.MaximumSalary,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdatePayGrade(PayGradesModel model)
        {
            var updatedPayGrade = await _context.PayGrades.FindAsync(model.Id);

            updatedPayGrade.Name = model.Name;
            updatedPayGrade.Currency = model.Currency;
            updatedPayGrade.MinimumSalary = model.MinimumSalary;
            updatedPayGrade.MaximumSalary = model.MaximumSalary;
            updatedPayGrade.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
