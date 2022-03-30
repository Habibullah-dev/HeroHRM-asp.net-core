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
    public class CurrencyController : Controller
    {
        private ICurrencyRepository _CurrencyRepository { get; set; }

        public CurrencyController(ICurrencyRepository CurrencyRepository)
        {
            _CurrencyRepository = CurrencyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _CurrencyRepository.GetCurrency();
            return View(obj);
        }

        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _CurrencyRepository.DeleteCurrency(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCurrency(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency(CurrencyModel currency)

        {
            if (ModelState.IsValid)
            {
                int id = await _CurrencyRepository.CreateCurrency(currency);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateCurrency), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditCurrency(int id, bool isSuccess = false)
        {
            var obj = await _CurrencyRepository.FindCurrency(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;
            data.CurrencyCode = obj.CurrencyCode;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCurrency(CurrencyModel model)
        {
            if (ModelState.IsValid)
            {
                await _CurrencyRepository.UpdateCurrency(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
