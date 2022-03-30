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
    public class LanguageController : Controller
    {
        private ILanguageRepository _languageRepository { get; set; }

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _languageRepository.GetLanguage();
            return View(obj);
        }

        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await _languageRepository.DeleteLanguage(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateLanguage(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(LanguageModel language)

        {
            if (ModelState.IsValid)
            {
                int id = await _languageRepository.CreateLanguage(language);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateLanguage), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditLanguage(int id, bool isSuccess = false)
        {
            var obj = await _languageRepository.FindLanguage(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                await _languageRepository.UpdateLanguage(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
