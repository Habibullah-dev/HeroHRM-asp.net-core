using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HolidayController : Controller
    {
        private IHolidayRepository _holidayRepository { get; set; }

        public HolidayController(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _holidayRepository.GetHolidays();
            return View(obj);
        }

        public async Task<IActionResult> DeleteHoliday(int id)
        {
            await _holidayRepository.DeleteHoliday(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateHoliday(bool isSuccess = false)
        {
            ViewBag.HolidayType = new SelectList(new List<string>() { "New Year", "Workers Day", "Fathers Day", "Sallah Day" });
            ViewBag.HolidayStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHoliday(HolidayModel holiday)

        {
            ViewBag.HolidayType = new SelectList(new List<string>() { "New Year", "Workers Day", "Fathers Day", "Sallah Day" });
            ViewBag.HolidayStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            if (ModelState.IsValid)
            {
                int id = await _holidayRepository.CreateHoliday(holiday);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateHoliday), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditHoliday(int id, bool isSuccess = false)
        {
            ViewBag.HolidayType = new SelectList(new List<string>() { "New Year", "Workers Day", "Fathers Day", "Sallah Day" });
            ViewBag.HolidayStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            var obj = await _holidayRepository.FindHolidays(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.HolidayType = obj.HolidayType;
            data.HolidayStatus = obj.HolidayStatus;
            data.NumberOfDays = obj.NumberOfDays;
            data.StartDate = obj.StartDate;
            data.EndDate = obj.EndDate;
            data.Comments = obj.Comments;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditHoliday(HolidayModel model)
        {
            ViewBag.HolidayType = new SelectList(new List<string>() { "New Year", "Workers Day", "Fathers Day", "Sallah Day" });
            ViewBag.HolidayStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            if (ModelState.IsValid)
            {
                await _holidayRepository.UpdateHoliday(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
