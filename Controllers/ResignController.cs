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
    [Authorize(Roles = "Employee")]
    public class ResignController : Controller
    {
        private IResignRepository _resignRepository { get; set; }

        public ResignController(IResignRepository resignRepository)
        {
            _resignRepository = resignRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _resignRepository.GetResigns();
            return View(obj);
        }

        public async Task<IActionResult> DeleteResign(int id)
        {
            await _resignRepository.DeleteResign(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateResign(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateResign(ResignModel holiday)

        {
            if (ModelState.IsValid)
            {
                int id = await _resignRepository.CreateResign(holiday);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateResign), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditResign(int id, bool isSuccess = false)
        {
            var obj = await _resignRepository.FindResigns(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.ResignationFile = obj.ResignationFile;
            data.Reason = obj.Reason;
            data.ResignationLetter = obj.ResignationLetter;
            data.Comments = obj.Comments;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditResign(ResignModel model)
        {
            if (ModelState.IsValid)
            {
                await _resignRepository.UpdateHResign(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
