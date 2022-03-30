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
    public class EducationController : Controller
    {
        private IEducationRepsoitory _educationRepository { get; set; }

        public EducationController(IEducationRepsoitory educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _educationRepository.GetEducation();
            return View(obj);
        }

        public async Task<IActionResult> DeleteEducation(int id)
        {
            await _educationRepository.DeleteEducation(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEducation(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation(EducationModel education)

        {
            if (ModelState.IsValid)
            {
                int id = await _educationRepository.CreateEducation(education);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateEducation), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditEducation(int id, bool isSuccess = false)
        {
            var obj = await _educationRepository.FindEducation(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEducation(EducationModel model)
        {
            if (ModelState.IsValid)
            {
                await _educationRepository.UpdateEducation(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
