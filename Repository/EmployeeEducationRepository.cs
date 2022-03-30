using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeEducationRepository : IEmployeeEducationRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeEducationRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeEducation(EmployeeEducationModel model)
        {
            var newEmployeeEducation = new EmployeeEducation()
            {
                Level = model.Level,
                Institute = model.Institute,
                Major = model.Major,
                Year = model.Year,
                Gpa = model.Gpa,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Comment = model.Comment,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeEducations.AddAsync(newEmployeeEducation);
            await _context.SaveChangesAsync();

            return newEmployeeEducation.Id;
        }

        public async Task DeleteEmployeeEducation(int id)
        {
            var foundEmployeeEducation = await _context.EmployeeEducations.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeEducation != null)
            {
                _context.Remove(foundEmployeeEducation);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeEducationModel> FindEmployeeEducation(int id)
        {
            return await _context.EmployeeEducations
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeEducationModel()
                 {
                     Id = x.Id,
                     Level = x.Level,
                     Institute = x.Institute,
                     Gpa = x.Gpa,
                     Major = x.Major,
                     Year = x.Year,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     Comment = x.Comment,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeEducationModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeEducations
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeEducationModel()
                 {
                     Id = x.Id,
                     Level = x.Level,
                     Institute = x.Institute,
                     Gpa = x.Gpa,
                     Major = x.Major,
                     Year = x.Year,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     Comment = x.Comment,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeEducation(EmployeeEducationModel model)
        {
            var updated = await _context.EmployeeEducations.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.Level = model.Level;
            updated.Institute = model.Institute;
            updated.Gpa = model.Gpa;
            updated.Major = model.Major;
            updated.Year = model.Year;
            updated.Comment = model.Comment;
            updated.StartDate = model.StartDate;
            updated.EndDate = model.EndDate;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
