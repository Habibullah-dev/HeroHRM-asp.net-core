using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly HeroHRMContext _context = null;
        public JobCategoryRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateJobCategory(JobCategoryModel model)
        {
            var newCategory = new JobCategories()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.JobCategories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return newCategory.Id;

        }

        public async Task<List<JobCategoryModel>> GetJobCategory()
        {
            return await _context.JobCategories
                 .Select(x => new JobCategoryModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteJobCategory(int id)
        {
            var foundCategory = await _context.JobCategories.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundCategory != null)
            {
                _context.Remove(foundCategory);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<JobCategoryModel> FindJobCategory(int id)
        {
            return await _context.JobCategories
                 .Where(x => x.Id == id)
                 .Select(x => new JobCategoryModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateJobCategory(JobCategoryModel model)
        {
            var updatedCategory = await _context.JobCategories.FindAsync(model.Id);

            updatedCategory.Name = model.Name;
            updatedCategory.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
