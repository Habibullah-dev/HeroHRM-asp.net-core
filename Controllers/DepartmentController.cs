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
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository { get; set; }

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _departmentRepository.GetDepartment();
            return View(obj);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateDepartment(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentModel department)

        {
            if (ModelState.IsValid)
            {
                int id = await _departmentRepository.CreateDepartment(department);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateDepartment), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditDepartment(int id, bool isSuccess = false)
        {
            var obj = await _departmentRepository.FindDepartment(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.Name;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateDepartment(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
