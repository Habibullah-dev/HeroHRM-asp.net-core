using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly HeroHRMContext _context = null;
        public LanguageRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLanguage(LanguageModel model)
        {
            var newLanguage = new Language()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Languages.AddAsync(newLanguage);
            await _context.SaveChangesAsync();

            return newLanguage.Id;

        }

        public async Task<List<LanguageModel>> GetLanguage()
        {
            return await _context.Languages
                 .Select(x => new LanguageModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteLanguage(int id)
        {
            var foundLanguage = await _context.Languages.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundLanguage != null)
            {
                _context.Remove(foundLanguage);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<LanguageModel> FindLanguage(int id)
        {
            return await _context.Languages
                 .Where(x => x.Id == id)
                 .Select(x => new LanguageModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateLanguage(LanguageModel model)
        {
            var updatedLanguage = await _context.Languages.FindAsync(model.Id);

            updatedLanguage.Name = model.Name;
            updatedLanguage.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
