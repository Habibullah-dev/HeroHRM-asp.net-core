using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeSkillRepository : IEmployeeSkillRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeSkillRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeSkill(EmployeeSkillModel model)
        {
            var newEmployeeSkill = new EmployeeSkill()
            {
                SkillId = model.SkillId,
                YearOfExperience = model.YearOfExperience,
                Comments = model.Comments,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeSkills.AddAsync(newEmployeeSkill);
            await _context.SaveChangesAsync();

            return newEmployeeSkill.Id;
        }

        public async Task DeleteEmployeeSkill(int id)
        {
            var foundEmployeeSkill = await _context.EmployeeSkills.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeSkill != null)
            {
                _context.Remove(foundEmployeeSkill);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeSkillModel> FindEmployeeSkill(int id)
        {
            return await _context.EmployeeSkills
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeSkillModel()
                 {
                     Id = x.Id,
                     SkillId = x.SkillId,
                     YearOfExperience = x.YearOfExperience,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeSkillModel> FindByEmployeeID(int id)
        {
            return await _context.EmployeeSkills
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeSkillModel()
                 {
                     Id = x.Id,
                     SkillId = x.SkillId,
                     Skill = x.Skill.Name,
                     YearOfExperience = x.YearOfExperience,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeSkill(EmployeeSkillModel model)
        {
            var updated = await _context.EmployeeSkills.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.SkillId = model.SkillId;
            updated.YearOfExperience = model.YearOfExperience;
            updated.Comments = model.Comments;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
