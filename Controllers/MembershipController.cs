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
    public class MembershipController : Controller
    {
        private IMembershipRepository _membershipRepository { get; set; }

        public MembershipController(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _membershipRepository.GetMembership();
            return View(obj);
        }

        public async Task<IActionResult> DeleteMembership(int id)
        {
            await _membershipRepository.DeleteMembership(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMembership(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembership(MembershipModel membership)

        {
            if (ModelState.IsValid)
            {
                int id = await _membershipRepository.CreateMembership(membership);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateMembership), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditMembership(int id, bool isSuccess = false)
        {
            var obj = await _membershipRepository.FindMembership(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditMembership(MembershipModel model)
        {
            if (ModelState.IsValid)
            {
                await _membershipRepository.UpdateMembership(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
