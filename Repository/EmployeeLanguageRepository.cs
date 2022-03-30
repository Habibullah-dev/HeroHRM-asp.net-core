using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeLanguageRepository : IEmployeeLanguageRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeLanguageRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeLanguage(EmployeeLanguageModel model)
        {
            var newEmployeeLanguage = new EmployeeLanguage()
            {
                LanguageId = model.LanguageId,
                Fluency = model.Fluency,
                Competency = model.Competency,
                Comments = model.Comments,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeLanguages.AddAsync(newEmployeeLanguage);
            await _context.SaveChangesAsync();

            return newEmployeeLanguage.Id;
        }

        public async Task DeleteEmployeeLanguage(int id)
        {
            var foundEmployeeLanguage = await _context.EmployeeLanguages.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeLanguage != null)
            {
                _context.Remove(foundEmployeeLanguage);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeLanguageModel> FindEmployeeLanguage(int id)
        {
            return await _context.EmployeeLanguages
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeLanguageModel()
                 {
                     Id = x.Id,
                     LanguageId = x.LanguageId,
                     Fluency = x.Fluency,
                     Competency = x.Competency,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeLanguageModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeLanguages
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeLanguageModel()
                 {
                     Id = x.Id,
                     LanguageId = x.LanguageId,
                     Fluency = x.Fluency,
                     Language = x.Language.Name,
                     Competency = x.Competency,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeLanguage(EmployeeLanguageModel model)
        {
            var updated = await _context.EmployeeLanguages.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.LanguageId = model.LanguageId;
            updated.Fluency = model.Fluency;
            updated.Competency = model.Competency;
            updated.Comments = model.Comments;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
