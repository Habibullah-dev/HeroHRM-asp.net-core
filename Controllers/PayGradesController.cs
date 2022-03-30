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
    public class PayGradesController : Controller
    {
        private IPayGradesRepository _payGradesRepository { get; set; }

        public PayGradesController(IPayGradesRepository payGradesRepository)
        {
            _payGradesRepository = payGradesRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _payGradesRepository.GetPayGrades();
            return View(obj);
        }

        public async Task<IActionResult> deletePayGrade(int id)
        {
            await _payGradesRepository.DeletePayGrade(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreatePayGrade(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayGrade(PayGradesModel payGrade)

        {
            if (ModelState.IsValid)
            {
                int id = await _payGradesRepository.CreatePayGrade(payGrade);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreatePayGrade), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditPayGrade(int id, bool isSuccess = false)
        {
            var obj = await _payGradesRepository.FindPayGrade(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;
            data.Currency = obj.Currency;
            data.MinimumSalary = obj.MinimumSalary;
            data.MaximumSalary = obj.MaximumSalary;
        
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPayGrade(PayGradesModel model)
        {
            if (ModelState.IsValid)
            {
                await _payGradesRepository.UpdatePayGrade(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
