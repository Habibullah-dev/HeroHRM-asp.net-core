using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeavesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        private ILeaveRepository _leaveRepository { get; set; }

        public LeavesController(ILeaveRepository leaveRepository,IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _leaveRepository.GetLeaves();
            return View(obj);
        }

        public async Task<IActionResult> DeleteLeave(int id)
        {
            await _leaveRepository.DeleteLeave(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateLeave(bool isSuccess = false)
        {
            ViewBag.Employee = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.LeaveType = new SelectList(new List<string>() { "vacation", "study" , "Personal" , "Matternity" });
            ViewBag.LeaveStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeave(LeaveModel leave)

        {
            ViewBag.Employee = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.LeaveType = new SelectList(new List<string>() { "vacation", "study", "Personal", "Matternity" });
            ViewBag.LeaveStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            if (ModelState.IsValid)
            {
                int id = await _leaveRepository.CreateLeave(leave);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(CreateLeave), new { isSuccess = true });
                }

            }

            return View();
        }

        public async Task<IActionResult> EditLeave(int id, bool isSuccess = false)
        {
            ViewBag.Employee = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.LeaveType = new SelectList(new List<string>() { "vacation", "study", "Personal", "Matternity" });
            ViewBag.LeaveStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            var obj = await _leaveRepository.FindLeaves(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.LeaveType = obj.LeaveType;
            data.LeaveStatus = obj.LeaveStatus;
            data.NumberOfDays  = obj.NumberOfDays;
            data.StartDate = obj.StartDate;
            data.EndDate = obj.EndDate;
            data.Comments = obj.Comments;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditLeave(LeaveModel model)
        {
            ViewBag.Employee = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.LeaveType = new SelectList(new List<string>() { "vacation", "study", "Personal", "Matternity" });
            ViewBag.LeaveStatus = new SelectList(new List<string>() { "Pending", "Approved", "Declined" });
            if (ModelState.IsValid)
            {
                await _leaveRepository.UpdateLeave(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
