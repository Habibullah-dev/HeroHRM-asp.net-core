using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class ResignRepository : IResignRepository
    {
        private readonly HeroHRMContext _context = null;
        public ResignRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateResign(ResignModel model)
        {
            var newResign = new Resign()
            {
                ResignationLetter = model.ResignationLetter,
                Reason = model.Reason,
                Comments = model.Comments,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Resigns.AddAsync(newResign);
            await _context.SaveChangesAsync();

            return newResign.Id;

        }

        public async Task<List<ResignModel>> GetResigns()
        {
            return await _context.Resigns
                 .Select(x => new ResignModel()
                 {
                     Id = x.Id,
                     Reason = x.Reason,
                     ResignationLetter = x.ResignationLetter,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteResign(int id)
        {
            var foundResign = await _context.Resigns.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundResign != null)
            {
                _context.Remove(foundResign);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<ResignModel> FindResigns(int id)
        {
            return await _context.Resigns
                 .Where(x => x.Id == id)
                 .Select(x => new ResignModel()
                 {
                     Id = x.Id,
                     ResignationLetter = x.ResignationLetter,
                     Reason = x.Reason,
                     Comments = x.Comments,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateHResign(ResignModel model)
        {
            var updated = await _context.Resigns.FindAsync(model.Id);

            updated.ResignationLetter = model.ResignationLetter;
            updated.Reason = model.Reason;
            updated.Comments = model.Comments;
            updated.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
