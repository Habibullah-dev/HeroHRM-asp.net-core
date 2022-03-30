using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly HeroHRMContext _context = null;
        public SkillRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateSkill(SkillModel model)
        {
            var newSkill = new Skill()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Skills.AddAsync(newSkill);
            await _context.SaveChangesAsync();

            return newSkill.Id;

        }

        public async Task<List<SkillModel>> GetSkill()
        {
            return await _context.Skills
                 .Select(x => new SkillModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteSkill(int id)
        {
            var foundSkill = await _context.Skills.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundSkill != null)
            {
                _context.Remove(foundSkill);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<SkillModel> FindSkill(int id)
        {
            return await _context.Skills
                 .Where(x => x.Id == id)
                 .Select(x => new SkillModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateSkill(SkillModel model)
        {
            var updatedSkill = await _context.Skills.FindAsync(model.Id);

            updatedSkill.Name = model.Name;
            updatedSkill.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
