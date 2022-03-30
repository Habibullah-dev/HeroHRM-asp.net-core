using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EducationRepsoitory : IEducationRepsoitory
    {
        private readonly HeroHRMContext _context = null;
        public EducationRepsoitory(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEducation(EducationModel model)
        {
            var newEducation = new Education()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Educations.AddAsync(newEducation);
            await _context.SaveChangesAsync();

            return newEducation.Id;

        }

        public async Task<List<EducationModel>> GetEducation()
        {
            return await _context.Educations
                 .Select(x => new EducationModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteEducation(int id)
        {
            var foundEducation = await _context.Educations.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEducation != null)
            {
                _context.Remove(foundEducation);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EducationModel> FindEducation(int id)
        {
            return await _context.Educations
                 .Where(x => x.Id == id)
                 .Select(x => new EducationModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEducation(EducationModel model)
        {
            var updatedEducation = await _context.Educations.FindAsync(model.Id);

            updatedEducation.Name = model.Name;
            updatedEducation.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
