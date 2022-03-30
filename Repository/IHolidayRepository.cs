using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IHolidayRepository
    {
        Task<int> CreateHoliday(HolidayModel model);
        Task DeleteHoliday(int id);
        Task<HolidayModel> FindHolidays(int id);
        Task<List<HolidayModel>> GetHolidays();
        Task UpdateHoliday(HolidayModel model);
    }
}