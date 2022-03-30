using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmploymentStatusController : Controller
    {
        private IEmploymentStatusRepository _employmentStatusRepository { get; set; }

        public EmploymentStatusController(IEmploymentStatusRepository employmentStatusRepository)
        {
            _employmentStatusRepository = employmentStatusRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _employmentStatusRepository.GetEmploymentStatus();
            return View(obj);
        }

        public async Task<IActionResult> DeleteEmploymentStatus(int id)
        {
            await _employmentStatusRepository.DeleteEmploymentStatus(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEmploymentStatus(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmploymentStatus(EmploymentStatusModel employmentStatus)

        {
            if (ModelState.IsValid)
            {
                int id = await _employmentStatusRepository.CreateEmploymentStatus(employmentStatus);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateEmploymentStatus), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditEmploymentStatus(int id, bool isSuccess = false)
        {
            var obj = await _employmentStatusRepository.FindEmploymentStatus(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmploymentStatus(EmploymentStatusModel model)
        {
            if (ModelState.IsValid)
            {
                await _employmentStatusRepository.UpdateEmploymentStatus(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
