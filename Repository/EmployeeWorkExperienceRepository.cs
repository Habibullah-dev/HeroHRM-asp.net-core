using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeWorkExperienceRepository : IEmployeeWorkExperienceRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeWorkExperienceRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateWorkExperienceModel(EmployeeWorkExperienceModel model)
        {
            var newEmployeeWorkExperience = new EmployeeWorkExperience()
            {
                CompanyName = model.CompanyName,
                JobTitle = model.JobTitle,
                From = model.From,
                To = model.To,
                Comment = model.Comment,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeWorkExperiences.AddAsync(newEmployeeWorkExperience);
            await _context.SaveChangesAsync();

            return newEmployeeWorkExperience.Id;
        }

        public async Task DeleteEmployeeWorkExperience(int id)
        {
            var foundEmployeeWorkExperience = await _context.EmployeeWorkExperiences.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeWorkExperience != null)
            {
                _context.Remove(foundEmployeeWorkExperience);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeWorkExperienceModel> FindEmployeeWorkExperience(int id)
        {
            return await _context.EmployeeWorkExperiences
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeWorkExperienceModel()
                 {
                     Id = x.Id,
                     CompanyName = x.CompanyName,
                     JobTitle = x.JobTitle,
                     From = x.From,
                     To = x.To,
                     Comment = x.Comment,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeWorkExperienceModel> FindByEmployeeID(int id)
        {
            return await _context.EmployeeWorkExperiences
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeWorkExperienceModel()
                 {
                     Id = x.Id,
                     CompanyName = x.CompanyName,
                     JobTitle = x.JobTitle,
                     From = x.From,
                     To = x.To,
                     Comment = x.Comment,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeWorkExperience(EmployeeWorkExperienceModel model)
        {
            var updated = await _context.EmployeeWorkExperiences.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.CompanyName = model.CompanyName;
            updated.JobTitle = model.JobTitle;
            updated.From = model.From;
            updated.To = model.To;
            updated.Comment = model.Comment;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
