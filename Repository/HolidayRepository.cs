using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly HeroHRMContext _context = null;
        public HolidayRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateHoliday(HolidayModel model)
        {
            var newHoliday = new Holiday()
            {
                HolidayStatus = model.HolidayStatus,
                HolidayType = model.HolidayType,
                NumberOfDays = model.NumberOfDays,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Comments = model.Comments,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Holidays.AddAsync(newHoliday);
            await _context.SaveChangesAsync();

            return newHoliday.Id;

        }

        public async Task<List<HolidayModel>> GetHolidays()
        {
            return await _context.Holidays
                 .Select(x => new HolidayModel()
                 {
                     Id = x.Id,
                     HolidayType = x.HolidayType,
                     HolidayStatus = x.HolidayStatus,
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

        public async Task DeleteHoliday(int id)
        {
            var foundHoliday = await _context.Holidays.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundHoliday != null)
            {
                _context.Remove(foundHoliday);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<HolidayModel> FindHolidays(int id)
        {
            return await _context.Holidays
                 .Where(x => x.Id == id)
                 .Select(x => new HolidayModel()
                 {
                     Id = x.Id,
                     HolidayStatus = x.HolidayStatus,
                     HolidayType = x.HolidayType,
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

        public async Task UpdateHoliday(HolidayModel model)
        {
            var updated = await _context.Holidays.FindAsync(model.Id);

            updated.HolidayType = model.HolidayType;
            updated.HolidayStatus = model.HolidayStatus;
            updated.Comments = model.Comments;
            updated.NumberOfDays = model.NumberOfDays;
            updated.StartDate = model.StartDate;
            updated.EndDate = model.EndDate;

            updated.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
