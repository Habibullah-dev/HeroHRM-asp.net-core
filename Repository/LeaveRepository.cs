using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly HeroHRMContext _context = null;
        public LeaveRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLeave(LeaveModel model)
        {
            var newLeave = new Leave()
            {
                LeaveStatus = model.LeaveStatus,
                EmployeeId = model.EmployeeId,
                LeaveType = model.LeaveType,
                NumberOfDays = model.NumberOfDays,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Comments = model.Comments,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Leaves.AddAsync(newLeave);
            await _context.SaveChangesAsync();

            return newLeave.Id;

        }

        public async Task<List<LeaveModel>> GetLeaves()
        {
            return await _context.Leaves
                 .Select(x => new LeaveModel()
                 {
                     Id = x.Id,
                     LeaveType = x.LeaveType,
                     EmployeeId = x.EmployeeId,
                     LeaveStatus = x.LeaveStatus,
                     NumberOfDays = x.NumberOfDays,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteLeave(int id)
        {
            var foundLeave = await _context.Leaves.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundLeave != null)
            {
                _context.Remove(foundLeave);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<LeaveModel> FindLeaves(int id)
        {
            return await _context.Leaves
                 .Where(x => x.Id == id)
                 .Select(x => new LeaveModel()
                 {
                     Id = x.Id,
                     LeaveStatus = x.LeaveStatus,
                     LeaveType = x.LeaveType,
                     NumberOfDays = x.NumberOfDays,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateLeave(LeaveModel model)
        {
            var updated = await _context.Leaves.FindAsync(model.Id);

            updated.LeaveType = model.LeaveType;
            updated.LeaveStatus = model.LeaveStatus;
            updated.Comments = model.Comments;
            updated.NumberOfDays = model.NumberOfDays;
            updated.StartDate = model.StartDate;
            updated.EndDate = model.EndDate;

            updated.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
