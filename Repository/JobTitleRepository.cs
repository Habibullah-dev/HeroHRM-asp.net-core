using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly HeroHRMContext _context = null;
        public JobTitleRepository(HeroHRMContext context)
        {
            _context = context;
        }

        public async Task<int> CreateJobTitle(JobTitleModel model)
        {
            var newJobTitle = new JobTitle()
            {
                Title = model.Title,
                CreatedDate= DateTime.UtcNow,
                Description = model.Description,
                UpdatedDate = DateTime.UtcNow,
            };



            await _context.JobTitle.AddAsync(newJobTitle);
            await _context.SaveChangesAsync();

            return newJobTitle.Id;

        }

        public async Task<List<JobTitleModel>> GetJobTitles()
        {
            return await _context.JobTitle
                 .Select(x => new JobTitleModel()
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Description = x.Description,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();
     
        }

        public async Task DeleteJobTitle(int id)
        {
            var foundJobTitle = await _context.JobTitle.Where(x => x.Id == id).FirstOrDefaultAsync();
            
          
            if(foundJobTitle != null)
            {
                _context.Remove(foundJobTitle);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<JobTitleModel> FindJobTitle(int id)
        {
            return await _context.JobTitle
                 .Where(x => x.Id == id)
                 .Select(x => new JobTitleModel()
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Description = x.Description,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateJobTitle(JobTitleModel model)
        {
            var updatedJobTitle = await _context.JobTitle.FindAsync(model.Id);

            updatedJobTitle.Title = model.Title;
            updatedJobTitle.Description = model.Description;
            updatedJobTitle.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }





    }


}
