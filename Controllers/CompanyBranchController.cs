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
    public class CompanyBranchController : Controller
    {
      
        private ICompanyBranchRepository _companyBranchRepository { get; set; }

        public CompanyBranchController(ICompanyBranchRepository companyBranchRepository)
        {
            _companyBranchRepository = companyBranchRepository;
        }

        public async Task<IActionResult> Index()
        {

            var obj = await _companyBranchRepository.GetCompanyBranch();
            return View(obj);
        }

        public async Task<IActionResult> DeleteCompanyBranch(int id)
        {
            await _companyBranchRepository.DeleteCompanyBranch(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCompanyBranch(bool isSuccess = false)
        {

            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyBranch(CompanyBranchModel companyBranch)

        {
            if (ModelState.IsValid)
            {
                int id = await _companyBranchRepository.CreateCompanyBranch(companyBranch);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateCompanyBranch), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditCompanyBranch(int id, bool isSuccess = false)
        {
            var obj = await _companyBranchRepository.FindCompanyBranch(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;
            data.City = obj.City;
            data.Country = obj.Country;
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCompanyBranch(CompanyBranchModel model)
        {
            if (ModelState.IsValid)
            {
                await _companyBranchRepository.UpdateCompanyBranch(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
