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
    public class JobTitleController : Controller
    {
        private IJobTitleRepository _JobTitleRepository { get; set; }

        public JobTitleController(IJobTitleRepository jobTitleRepository)
        {
            _JobTitleRepository = jobTitleRepository;
        }

        public async Task<IActionResult> Index()
        {
           var obj =  await _JobTitleRepository.GetJobTitles();
            return View(obj);
        }

        public async Task<IActionResult> deleteJobTitle(int id)
        {
           await _JobTitleRepository.DeleteJobTitle(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateJobTitle(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobTitle(JobTitleModel jobtitle )

        {
            if(ModelState.IsValid)
            {
                int id = await _JobTitleRepository.CreateJobTitle(jobtitle);
                if(id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateJobTitle), new { isSuccess = true});
                }

            }
          
            return View();
        }

        public async Task<IActionResult> EditJobTitle( int id , bool isSuccess = false)
        {
            var obj = await _JobTitleRepository.FindJobTitle(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Title = obj.Title;
            data.Description = obj.Description;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditJobTitle(JobTitleModel model)
        {
            if(ModelState.IsValid)
            {
                await  _JobTitleRepository.UpdateJobTitle(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
