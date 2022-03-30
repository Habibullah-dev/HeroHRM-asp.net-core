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
    public class SKillController : Controller
    {
        private ISkillRepository _SKillRepository { get; set; }

        public SKillController(ISkillRepository SKillRepository)
        {
            _SKillRepository = SKillRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _SKillRepository.GetSkill();
            return View(obj);
        }

        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _SKillRepository.DeleteSkill(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateSKill(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(SkillModel skill)

        {
            if (ModelState.IsValid)
            {
                int id = await _SKillRepository.CreateSkill(skill);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateSkill), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditSKill(int id, bool isSuccess = false)
        {
            var obj = await _SKillRepository.FindSkill(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditSkill(SkillModel model)
        {
            if (ModelState.IsValid)
            {
                await _SKillRepository.UpdateSkill(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
