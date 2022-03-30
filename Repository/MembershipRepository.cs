using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly HeroHRMContext _context = null;
        public MembershipRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateMembership(MembershipModel model)
        {
            var newMembership = new Membership()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Memberships.AddAsync(newMembership);
            await _context.SaveChangesAsync();

            return newMembership.Id;

        }

        public async Task<List<MembershipModel>> GetMembership()
        {
            return await _context.Memberships
                 .Select(x => new MembershipModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteMembership(int id)
        {
            var foundMembership = await _context.Memberships.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundMembership != null)
            {
                _context.Remove(foundMembership);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<MembershipModel> FindMembership(int id)
        {
            return await _context.Memberships
                 .Where(x => x.Id == id)
                 .Select(x => new MembershipModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateMembership(MembershipModel model)
        {
            var updatedMembership = await _context.Memberships.FindAsync(model.Id);

            updatedMembership.Name = model.Name;
            updatedMembership.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
