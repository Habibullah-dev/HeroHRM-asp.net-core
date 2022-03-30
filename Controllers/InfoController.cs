using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
    [Authorize(Roles = "Employee")]
    public class InfoController : Controller
    {
        private readonly IResignRepository _resignRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InfoController(IResignRepository resignRepository, IWebHostEnvironment webHostEnvironment)
        {
            _resignRepository = resignRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resign(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Resign(ResignModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ResignationFile != null)
                {
                    string folder = "Images/Resign/";
                    folder += Guid.NewGuid().ToString() + "_" + model.ResignationFile.FileName;

                    model.ResignationLetter = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await model.ResignationFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));


                }
                int id = await _resignRepository.CreateResign(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
    }
}
