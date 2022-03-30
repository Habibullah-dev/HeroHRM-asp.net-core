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
    public class LicenseController : Controller
    {
        private ILicenseRepository _licenseRepository { get; set; }

        public LicenseController(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _licenseRepository.GetLicense();
            return View(obj);
        }

        public async Task<IActionResult> DeleteLicense(int id)
        {
            await _licenseRepository.DeleteLicense(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateLicense(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLicense(LicenseModel license)

        {
            if (ModelState.IsValid)
            {
                int id = await _licenseRepository.CreateLicense(license);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateLicense), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditLicense(int id, bool isSuccess = false)
        {
            var obj = await _licenseRepository.FindLicense(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditLicense(LicenseModel model)
        {
            if (ModelState.IsValid)
            {
                await _licenseRepository.UpdateLicense(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
