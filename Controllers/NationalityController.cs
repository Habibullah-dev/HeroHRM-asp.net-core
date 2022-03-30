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
    public class NationalityController : Controller
    {
        private INationalityRepository _nationalityRepository { get; set; }

        public NationalityController(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _nationalityRepository.GetNationality();
            return View(obj);
        }

        public async Task<IActionResult> DeleteNationality(int id)
        {
            await _nationalityRepository.DeleteNationality(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateNationality(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNationality(NationalityModel nationality)

        {
            if (ModelState.IsValid)
            {
                int id = await _nationalityRepository.CreateNationality(nationality);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateNationality), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> Editnationality(int id, bool isSuccess = false)
        {
            var obj = await _nationalityRepository.FindNationality(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Editnationality(NationalityModel model)
        {
            if (ModelState.IsValid)
            {
                await _nationalityRepository.UpdateNationality(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
