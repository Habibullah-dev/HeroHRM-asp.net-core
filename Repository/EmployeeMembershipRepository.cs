using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeMembershipRepository : IEmployeeMembershipRepository
    {

        private readonly HeroHRMContext _context = null;
        public EmployeeMembershipRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeMembership(EmployeeMembershipModel model)
        {
            var newEmployeeMembership = new EmployeeMembership()
            {
                MembershipId = model.MembershipId,
                ReportingMethod = model.ReportingMethod,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeMemberships.AddAsync(newEmployeeMembership);
            await _context.SaveChangesAsync();

            return newEmployeeMembership.Id;
        }

        public async Task DeleteEmployeeMembership(int id)
        {
            var foundEmployeeMembership = await _context.EmployeeMemberships.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (foundEmployeeMembership != null)
            {
                _context.Remove(foundEmployeeMembership);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeMembershipModel> FindEmployeeMembership(int id)
        {
            return await _context.EmployeeMemberships
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeMembershipModel()
                 {
                     Id = x.Id,
                     MembershipId = x.MembershipId,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeMembershipModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeMemberships
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeMembershipModel()
                 {
                     Id = x.Id,
                     MembershipId = x.MembershipId,
                     Membership = x.Membership.Name,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeMembership(EmployeeMembershipModel model)
        {
            var updated = await _context.EmployeeMemberships.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.MembershipId = model.MembershipId;
            updated.ReportingMethod = model.ReportingMethod;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
