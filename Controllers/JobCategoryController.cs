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
    public class JobCategoryController : Controller
    {
        private IJobCategoryRepository _jobCategoryRepository { get; set; }

        public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _jobCategoryRepository.GetJobCategory();
            return View(obj);
        }

        public async Task<IActionResult> DeleteEmploymentStatus(int id)
        {
            await _jobCategoryRepository.DeleteJobCategory(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateJobCategory(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobCategory(JobCategoryModel jobCategory)

        {
            if (ModelState.IsValid)
            {
                int id = await _jobCategoryRepository.CreateJobCategory(jobCategory);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateJobCategory), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditJobCategory(int id, bool isSuccess = false)
        {
            var obj = await _jobCategoryRepository.FindJobCategory(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditJobCategory(JobCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await _jobCategoryRepository.UpdateJobCategory(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
