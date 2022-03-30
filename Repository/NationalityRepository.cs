using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly HeroHRMContext _context = null;
        public NationalityRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateNationality(NationalityModel model)
        {
            var newNationality = new Nationality()
            {
                Name = model.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Nationalities.AddAsync(newNationality);
            await _context.SaveChangesAsync();

            return newNationality.Id;

        }

        public async Task<List<NationalityModel>> GetNationality()
        {
            return await _context.Nationalities
                 .Select(x => new NationalityModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteNationality(int id)
        {
            var foundNationality = await _context.Nationalities.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundNationality != null)
            {
                _context.Remove(foundNationality);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<NationalityModel> FindNationality(int id)
        {
            return await _context.Nationalities
                 .Where(x => x.Id == id)
                 .Select(x => new NationalityModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateNationality(NationalityModel model)
        {
            var updatedNationality = await _context.Nationalities.FindAsync(model.Id);

            updatedNationality.Name = model.Name;
            updatedNationality.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
