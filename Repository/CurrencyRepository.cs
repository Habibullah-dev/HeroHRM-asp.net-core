using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly HeroHRMContext _context = null;
        public CurrencyRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCurrency(CurrencyModel model)
        {
            var newCurrency = new Currency()
            {
                Name = model.Name,
                CurrencyCode = model.CurrencyCode,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            await _context.Currencies.AddAsync(newCurrency);
            await _context.SaveChangesAsync();

            return newCurrency.Id;

        }

        public async Task<List<CurrencyModel>> GetCurrency()
        {
            return await _context.Currencies
                 .Select(x => new CurrencyModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CurrencyCode = x.CurrencyCode,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }

        public async Task DeleteCurrency(int id)
        {
            var foundCurrency = await _context.Currencies.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundCurrency != null)
            {
                _context.Remove(foundCurrency);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<CurrencyModel> FindCurrency(int id)
        {
            return await _context.Currencies
                 .Where(x => x.Id == id)
                 .Select(x => new CurrencyModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CurrencyCode = x.CurrencyCode,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateCurrency(CurrencyModel model)
        {
            var updatedCurrency = await _context.Currencies.FindAsync(model.Id);

            updatedCurrency.Name = model.Name;
            updatedCurrency.CurrencyCode = model.CurrencyCode;
            updatedCurrency.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
