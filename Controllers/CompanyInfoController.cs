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
    public class CompanyInfoController : Controller
    {
        private ICompanyInfoRepository _companyInfoRepository { get; set; }

        public CompanyInfoController(ICompanyInfoRepository companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _companyInfoRepository.GetCompanyInfo();
            return View(obj);
        }

        public async Task<IActionResult> DeleteCompanyInfo(int id)
        {
            await _companyInfoRepository.DeleteCompanyInfo(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCompanyInfo(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyInfo(CompanyInfoModel companyInfo)

        {
            if (ModelState.IsValid)
            {
                int id = await _companyInfoRepository.CreateCompanyInfo(companyInfo);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateCompanyInfo), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditCompanyInfo(int id, bool isSuccess = false)
        {
            var obj = await _companyInfoRepository.FindCompanyInfo(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;
            data.TaxId = obj.TaxId;
            data.EmployeeNumbers = obj.EmployeeNumbers;
            data.RegistrationNumber = obj.RegistrationNumber;
            data.Phone = obj.Phone;
            data.Email = obj.Email;
            data.Fax = obj.Fax;
            data.Address = obj.Address;
            data.City = obj.City;
            data.State = obj.State;
            data.ZipCode = obj.ZipCode;
            data.Country = obj.Country;
          

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCompanyInfo(CompanyInfoModel model)
        {
            if (ModelState.IsValid)
            {
                await _companyInfoRepository.UpdateCompanyInfo(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
