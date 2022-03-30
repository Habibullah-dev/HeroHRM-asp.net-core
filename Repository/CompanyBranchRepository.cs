using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class CompanyBranchRepository : ICompanyBranchRepository
    {
        private readonly HeroHRMContext _context = null;
        public CompanyBranchRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCompanyBranch(CompanyBranchModel model)
        {
            var newBranch = new CompanyBranch()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.CompanyBranches.AddAsync(newBranch);
            await _context.SaveChangesAsync();

            return newBranch.Id;

        }

        public async Task<List<CompanyBranchModel>> GetCompanyBranch()
        {
            return await _context.CompanyBranches
                 .Select(x => new CompanyBranchModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     City = x.City,
                     Country = x.Country,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteCompanyBranch(int id)
        {
            var foundBranch = await _context.CompanyBranches.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundBranch != null)
            {
                _context.Remove(foundBranch);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<CompanyBranchModel> FindCompanyBranch(int id)
        {
            return await _context.CompanyBranches
                 .Where(x => x.Id == id)
                 .Select(x => new CompanyBranchModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     City = x.City,
                     Country = x.Country,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateCompanyBranch(CompanyBranchModel model)
        {
            var updatedBranch = await _context.CompanyBranches.FindAsync(model.Id);

            updatedBranch.Name = model.Name;
            updatedBranch.City = model.City;
            updatedBranch.Country = model.Country;
            updatedBranch.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
