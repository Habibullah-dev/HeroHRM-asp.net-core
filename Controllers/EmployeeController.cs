using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly INationalityRepository _nationalityRepository;
        private readonly IEmployeeContactRepository _employeeContactRepository;
        private readonly IEmployeeDependantRepository _employeeDependantRepository;
        private readonly IEmployeeImmigrationRepository _employeeImmigrationRepository;
        private readonly IEmployeeEmergencyRepository _employeeEmergencyRepository;
        private readonly IEmployeeJobRepository _employeeJobRepository;
        private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IEmploymentStatusRepository _employmentStatusRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IEmployeeWorkExperienceRepository _employeeWorkExperienceRepository;
        private readonly IEmployeeEducationRepository _employeeEducationRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IEmployeeLanguageRepository _employeeLanguageRepository;
        private readonly IEmployeeLicenseRepository _employeeLicenseRepository;
        private readonly IEmployeeSupervisorRepository _employeeSupervisorRepository;
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IEmployeeSubordinateRepository _employeeSubordinateRepository;
        private readonly IEmployeeMembershipRepository _employeeMembershipRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyBranchRepository _companyBranchRepository;
        private readonly IPayGradesRepository _payGradesRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository,
            IUserRepository userRepository,
            INationalityRepository nationalityRepository,
            IEmployeeContactRepository employeeContactRepository,
            IEmployeeDependantRepository employeeDependantRepository,
            IEmployeeImmigrationRepository employeeImmigrationRepository,
            IEmployeeEmergencyRepository employeeEmergencyRepository,
            IEmployeeJobRepository employeeJobRepository,
            IEmployeeSalaryRepository employeeSalaryRepository,
            IJobTitleRepository jobTitleRepository,
            IEmploymentStatusRepository employmentStatusRepository,
            ICurrencyRepository currencyRepository,
            IEmployeeWorkExperienceRepository employeeWorkExperienceRepository,
            IEmployeeEducationRepository employeeEducationRepository,
            IEmployeeSkillRepository employeeSkillRepository,
            IEmployeeLanguageRepository employeeLanguageRepository,
            IEmployeeLicenseRepository employeeLicenseRepository,
            IEmployeeSupervisorRepository employeeSupervisorRepository,
            IJobCategoryRepository jobCategoryRepository,
            IMembershipRepository membershipRepository,
            IEmployeeSubordinateRepository employeeSubordinateRepository,
            IEmployeeMembershipRepository employeeMembershipRepository,
            IDepartmentRepository departmentRepository,
            ICompanyBranchRepository companyBranchRepository,
            IPayGradesRepository payGradesRepository,
            ILanguageRepository languageRepository,
            ISkillRepository skillRepository,
            ILicenseRepository licenseRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _nationalityRepository = nationalityRepository;
            _employeeContactRepository = employeeContactRepository;
            _employeeDependantRepository = employeeDependantRepository;
            _employeeImmigrationRepository = employeeImmigrationRepository;
            _employeeEmergencyRepository = employeeEmergencyRepository;
            _employeeJobRepository = employeeJobRepository;
            _employeeSalaryRepository = employeeSalaryRepository;
            _jobTitleRepository = jobTitleRepository;
            _employmentStatusRepository = employmentStatusRepository;
            _currencyRepository = currencyRepository;
            _employeeWorkExperienceRepository = employeeWorkExperienceRepository;
            _employeeEducationRepository = employeeEducationRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _employeeLanguageRepository = employeeLanguageRepository;
            _employeeLicenseRepository = employeeLicenseRepository;
            _employeeSupervisorRepository = employeeSupervisorRepository;
            _jobCategoryRepository = jobCategoryRepository;
            _membershipRepository = membershipRepository;
            _employeeSubordinateRepository = employeeSubordinateRepository;
            _employeeMembershipRepository = employeeMembershipRepository;
            _departmentRepository = departmentRepository;
            _companyBranchRepository = companyBranchRepository;
            _payGradesRepository = payGradesRepository;
            _languageRepository = languageRepository;
            _skillRepository = skillRepository;
            _licenseRepository = licenseRepository;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var obj = await _employeeRepository.GetEmployee();
            return View(obj);
        }

        public async Task<IActionResult> Details(int id)
        {
            var obj = await _employeeRepository.FindEmployee(id);
            
            return View(obj);
        }

        //.....................Employee Peronal Information............................................
        public async Task<IActionResult> CreatePersonal(bool isSuccess=false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.Users = new SelectList(await _userRepository.GetAllUsers(), "Id", "UserName");
            ViewBag.Nationality = new SelectList (await _nationalityRepository.GetNationality(),"Id" , "Name" );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonal(EmployeeModel model)
        {
            ViewBag.Users = new SelectList(await _userRepository.GetAllUsers(),"Id" , "UserName");
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");

            if(ModelState.IsValid)
            {
                if(model.Image != null)
                {
                    string folder = "Images/Photo/";
                    folder += Guid.NewGuid().ToString() + "_" + model.Image.FileName;

                    model.Photograph = "/" + folder;
                   
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await model.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));


                }
                int id = await _employeeRepository.CreateEmployee(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployee(int id, bool isSuccess = false)
        {
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");
            var obj = await _employeeRepository.FindEmployee(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.FirstName = obj.FirstName;
            data.MiddleName = obj.MiddleName;
            data.LastName = obj.LastName;
            data.UserId = obj.UserId;
            data.Gender = obj.Gender;
            data.DateOfBirth = obj.DateOfBirth;
            data.MaritalStatus = obj.MaritalStatus;
            data.NationalityId = obj.NationalityId;
      
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeModel model)
        {
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");
            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateEmployee(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }



        //.....................Employee Conatct Detail Information............................................
        public IActionResult CreateContact(int EmployeeId ,bool isSuccess = false)
        {
            ViewBag.EmployeeId = EmployeeId;
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(EmployeeContactModel model )
        {
          
            if (ModelState.IsValid)
            {
                
                int id = await _employeeContactRepository.CreateEmployeeContact(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditContact(int id, bool isSuccess = false)
        {
            var obj = await _employeeContactRepository.FindEmployeeContact(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.HomeTelephone = obj.HomeTelephone;
            data.Mobile = obj.Mobile;
            data.Fax = obj.Fax;
            data.Email = obj.Email;
            data.WorkEmail = obj.WorkEmail;
            data.WorkTelephone = obj.WorkTelephone;
            data.OtherEmail = obj.OtherEmail;
            data.Phone = obj.Phone;
            data.Address = obj.Address;
            data.City = obj.City;
            data.State = obj.State;
            data.ZipCode = obj.ZipCode;
            data.Country = obj.Country;
           
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(EmployeeContactModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeContactRepository.UpdateEmployeeContact(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Emergency Contact............................................
        public IActionResult CreateEmergencyContact(int EmployeeId ,bool isSuccess = false)
        {
            ViewBag.EmployeeId = EmployeeId;
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmergencyContact(EmployeeEmergencyModel model)
        {

            if (ModelState.IsValid)
            {

                int id = await _employeeEmergencyRepository.CreateEmployeeEmergency(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmergencyContact(int id, bool isSuccess = false)
        {
            var obj = await _employeeEmergencyRepository.FindEmployeeEmergency(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.HomeTelephone = obj.HomeTelephone;
            data.Mobile = obj.Mobile;
            data.Name = obj.Name;
            data.WorkTelephone = obj.WorkTelephone;
            data.Relationship = obj.Relationship;
 
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmergencyContact(EmployeeEmergencyModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeEmergencyRepository.UpdateEmployeeEmergency(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Dependant............................................
        public IActionResult CreateEmployeeDependant(int EmployeeId ,bool isSuccess = false)
        {
            ViewBag.EmployeeId = EmployeeId;
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeDependant(EmployeeDependantModel model)
        {
            model.Id = ++model.Id;
            if (ModelState.IsValid)
            {
               
                int id = await _employeeDependantRepository.CreateEmployeeDependant(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeDependant(int id, bool isSuccess = false)
        {
            var obj = await _employeeDependantRepository.FindEmployeeDependant(id);
            ViewBag.isSuccess = isSuccess;

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.DateOfBirth = obj.DateOfBirth;
            data.Name = obj.Name;
            data.Relationship = obj.Relationship;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeDependant(EmployeeDependantModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeDependantRepository.UpdateEmployeeDependant(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Immigration............................................

        public async Task<IActionResult> CreateEmployeeImmigration(bool isSuccess = false)
        {
            ViewBag.DocumentType = new SelectList(new List<string> { "Passport", "Visa" });
            ViewBag.Nationality = new SelectList( await _nationalityRepository.GetNationality(), "Id", "Name");
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeImmigration(EmployeeImmigrationModel model)
        {
            ViewBag.DocumentType = new SelectList( new List<string> { "Passport", "Visa" });
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");
            if (ModelState.IsValid)
            {

                int id = await _employeeImmigrationRepository.CreateEmployeeImmigration(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeImmigration(int id, bool isSuccess = false)
        {
            var obj = await _employeeImmigrationRepository.FindEmployeeImmigration(id);
            ViewBag.isSuccess = isSuccess;
            ViewBag.DocumentType = new SelectList(new List<string> { "Passport", "Visa" });
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.DocumentType = obj.DocumentType;
            data.Number = obj.Number;
            data.IssuedDate = obj.IssuedDate;
            data.IssuedBy = obj.IssuedBy;
            data.ExpiryDate = obj.ExpiryDate;
            data.EligibleStatus = obj.EligibleStatus;
            data.EligibleReviewDate = obj.EligibleReviewDate;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeImmigration(EmployeeImmigrationModel model)
        {
            ViewBag.DocumentType = new SelectList(new List<string> { "Passport", "Visa" });
            ViewBag.Nationality = new SelectList(await _nationalityRepository.GetNationality(), "Id", "Name");
            if (ModelState.IsValid)
            {
                await _employeeImmigrationRepository.UpdateEmployeeImmigration(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Job............................................
        public async Task<IActionResult> CreateEmployeeJob(bool isSuccess = false)
        {
            ViewBag.JobTitle = new SelectList(await _jobTitleRepository.GetJobTitles(), "Id", "Title");
            ViewBag.EmploymentStatus = new SelectList(await _employmentStatusRepository.GetEmploymentStatus(), "Id", "Name");
            ViewBag.JobCategory = new SelectList(await _jobCategoryRepository.GetJobCategory(), "Id", "Name");
            ViewBag.Department = new SelectList(await _departmentRepository.GetDepartment(), "Id", "Name");
            ViewBag.CompanyBranch = new SelectList(await _companyBranchRepository.GetCompanyBranch(), "Id", "Name");
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeJob(EmployeeJobModel model)
        {
            ViewBag.JobTitle = new SelectList(await _jobTitleRepository.GetJobTitles(), "Id", "Title");
            ViewBag.EmploymentStatus = new SelectList(await _employmentStatusRepository.GetEmploymentStatus(), "Id", "Name");
            ViewBag.JobCategory = new SelectList(await _jobCategoryRepository.GetJobCategory(), "Id", "Name");
            ViewBag.Department = new SelectList(await _departmentRepository.GetDepartment(), "Id", "Name");
            ViewBag.CompanyBranch = new SelectList(await _companyBranchRepository.GetCompanyBranch(), "Id", "Name");

            if (ModelState.IsValid)
            {

                int id = await _employeeJobRepository.CreateEmployeeJob(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeJob(int id, bool isSuccess = false)
        {
            ViewBag.JobTitle = new SelectList(await _jobTitleRepository.GetJobTitles(), "Id", "Title");
            ViewBag.EmploymentStatus = new SelectList(await _employmentStatusRepository.GetEmploymentStatus(), "Id", "Name");
            ViewBag.JobCategory = new SelectList(await _jobCategoryRepository.GetJobCategory(), "Id", "Name");
            ViewBag.Department = new SelectList(await _departmentRepository.GetDepartment(), "Id", "Name");
            ViewBag.CompanyBranch = new SelectList(await _companyBranchRepository.GetCompanyBranch(), "Id", "Name");

            var obj = await _employeeJobRepository.FindEmployeeJob(id);
            ViewBag.isSuccess = isSuccess;
           

            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.JobTitleId = obj.JobTitleId;
            data.EmploymentStatusId = obj.EmploymentStatusId;
            data.JobCategoryId = obj.JobCategoryId;
            data.DepartmentId = obj.DepartmentId;
            data.CompanyBranchId = obj.CompanyBranchId;
            data.ContractStart = obj.ContractStart;
            data.ContractEnd = obj.ContractEnd;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeJob(EmployeeJobModel model)
        {
            ViewBag.JobTitle = new SelectList(await _jobTitleRepository.GetJobTitles(), "Id", "Title");
            ViewBag.EmploymentStatus = new SelectList(await _employmentStatusRepository.GetEmploymentStatus(), "Id", "Name");
            ViewBag.JobCategory = new SelectList(await _jobCategoryRepository.GetJobCategory(), "Id", "Name");
            ViewBag.Department = new SelectList(await _departmentRepository.GetDepartment(), "Id", "Name");
            ViewBag.CompanyBranch = new SelectList(await _companyBranchRepository.GetCompanyBranch(), "Id", "Name");
           
            if (ModelState.IsValid)
            {
                await _employeeJobRepository.UpdateEmployeeJob(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Salary.........................................
        public async Task<IActionResult> CreateEmployeeSalary(bool isSuccess = false)
        {
            ViewBag.PayGrade = new SelectList(await _payGradesRepository.GetPayGrades(), "Id", "Name");
            ViewBag.PayFrequency = new SelectList(new List<string> { "Bi-Weekly", "Hourly" , "Monthly","Semi-Monthly","Yearly" });
            ViewBag.Currency = new SelectList(await _currencyRepository.GetCurrency(), "Id", "Name");
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeSalary(EmployeeSalaryModel model)
        {
            ViewBag.PayGrade = new SelectList(await _payGradesRepository.GetPayGrades(), "Id", "Name");
            ViewBag.PayFrequency = new SelectList(new List<string> { "Bi-Weekly", "Hourly", "Monthly", "Semi-Monthly", "Yearly" });
            ViewBag.Currency = new SelectList(await _currencyRepository.GetCurrency(), "Id", "Name");
            if (ModelState.IsValid)
            {

                int id = await _employeeSalaryRepository.CreateEmployeeSalary(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeSalary(int id, bool isSuccess = false)
        {
            ViewBag.PayGrade = new SelectList(await _payGradesRepository.GetPayGrades(), "Id", "Name");
            ViewBag.PayFrequency = new SelectList(new List<string> { "Bi-Weekly", "Hourly", "Monthly", "Semi-Monthly", "Yearly" });
            ViewBag.Currency = new SelectList(await _currencyRepository.GetCurrency(), "Id", "Name");

            var obj = await _employeeSalaryRepository.FindEmployeeSalary(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.PayGradeId = obj.PayGradeId;
            data.PayFrequency = obj.PayFrequency;
            data.CuurencyId = obj.CuurencyId;
            data.Amount = obj.Amount;
      
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeSalary(EmployeeSalaryModel model)
        {
            ViewBag.PayGrade = new SelectList(await _payGradesRepository.GetPayGrades(), "Id", "Name");
            ViewBag.PayFrequency = new SelectList(new List<string> { "Bi-Weekly", "Hourly", "Monthly", "Semi-Monthly", "Yearly" });
            ViewBag.Currency = new SelectList(await _currencyRepository.GetCurrency(), "Id", "Name");

            if (ModelState.IsValid)
            {
                await _employeeSalaryRepository.UpdateEmployeeSalary(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Membership............................................

        public async Task<IActionResult> CreateEmployeeMembership(bool isSuccess = false)
        {
            ViewBag.Membership = new SelectList(await _membershipRepository.GetMembership(), "Id", "Name");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });
      
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeMembership(EmployeeMembershipModel model)
        {
            ViewBag.Membership = new SelectList(await _membershipRepository.GetMembership(), "Id", "Name");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {

                int id = await _employeeMembershipRepository.CreateEmployeeMembership(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeMembership(int id, bool isSuccess = false)
        {
            ViewBag.Subordinate = new SelectList(await _membershipRepository.GetMembership(), "Id", "Name");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            var obj = await _employeeMembershipRepository.FindEmployeeMembership(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.MembershipId;
            data.PayFrequency = obj.ReportingMethod;
       
            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeMembership(EmployeeMembershipModel model)
        {
            ViewBag.Subordinate = new SelectList(await _membershipRepository.GetMembership(), "Id", "Name");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {
                await _employeeMembershipRepository.UpdateEmployeeMembership(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Subordinate............................................
        public async Task<IActionResult> CreateEmployeeSubordinate(bool isSuccess = false)
        {
            ViewBag.SubordinateId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeSubordinate(EmployeeSubordinateModel model)
        {
            ViewBag.SubordinateId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {

                int id = await _employeeSubordinateRepository.CreateEmployeeSubordinate(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeSubordinate(int id, bool isSuccess = false)
        {
            ViewBag.SubordinateId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            var obj = await _employeeSubordinateRepository.FindEmployeeSubordinate(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Subordinate = obj.Subordinate;
            data.PayFrequency = obj.ReportingMethod;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeSubordinate(EmployeeSubordinateModel model)
        {
            ViewBag.SubordinateId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {
                await _employeeSubordinateRepository.UpdateEmployeeSubordinate(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Supervisor............................................
        public async Task<IActionResult> CreateEmployeeSupervisor(bool isSuccess = false)
        {
            ViewBag.SupervisorId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeSupervisor(EmployeeSupervisorModel model)
        {
            ViewBag.SupervisorId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {

                int id = await _employeeSupervisorRepository.CreateEmployeeSupervisor(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeSupervisor(int id, bool isSuccess = false)
        {
            ViewBag.SupervisorId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            var obj = await _employeeSupervisorRepository.FindEmployeeSupervisor(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Supervisor = obj.Supervisor;
            data.PayFrequency = obj.ReportingMethod;

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeSupervisor(EmployeeSupervisorModel model)
        {
            ViewBag.SupervisorId = new SelectList(await _employeeRepository.GetEmployee(), "Id", "FirstName");
            ViewBag.ReportingMethod = new SelectList(new List<string> { "Direct", "Indeirect", "Others" });

            if (ModelState.IsValid)
            {
                await _employeeSupervisorRepository.UpdateEmployeeSupervisor(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Work Experience............................................

        public IActionResult CreateEmployeeWorkExperience(bool isSuccess = false)
        {
        
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeWorkExperience(EmployeeWorkExperienceModel model)
        {
          
            if (ModelState.IsValid)
            {

                int id = await _employeeWorkExperienceRepository.CreateWorkExperienceModel(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeWorkExperience(int id, bool isSuccess = false)
        {

            var obj = await _employeeWorkExperienceRepository.FindEmployeeWorkExperience(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Name = obj.CompanyName;
            data.JobTitle = obj.JobTitle;
            data.From = obj.From;
            data.To = obj.To;
            data.Comment = obj.Comment;
                          

            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeWorkExperience(EmployeeWorkExperienceModel model)
        {

            if (ModelState.IsValid)
            {
                await _employeeWorkExperienceRepository.UpdateEmployeeWorkExperience(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Education............................................

        public IActionResult CreateEmployeeEducation(int EmployeeId,bool isSuccess = false)
        {
            ViewBag.Level = new SelectList(new List<string> { "Post Graduate", "Graduate", "Secondary" });
            ViewBag.isSuccess = isSuccess;
            ViewBag.EmployeeId = EmployeeId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeEducation(EmployeeEducationModel model)
        {
            ViewBag.Level = new SelectList(new List<string> { "Post Graduate", "Graduate", "Secondary" });

            if (ModelState.IsValid)
            {

                int id = await _employeeEducationRepository.CreateEmployeeEducation(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeEducation(int id, bool isSuccess = false)
        {
            ViewBag.Level = new SelectList(new List<string> { "Post Graduate", "Graduate", "Secondary" });
            var obj = await _employeeEducationRepository.FindEmployeeEducation(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.Level = obj.Level;
            data.Institute = obj.Institute;
            data.Year = obj.Year;
            data.Major = obj.Major;
            data.Gpa = obj.Gpa;
            data.StartDate = obj.StartDate;
            data.EndDate = obj.EndDate;
            data.Comment = obj.Comment;


            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeEducation(EmployeeEducationModel model)
        {
            ViewBag.Level = new SelectList(new List<string> { "Post Graduate", "Graduate", "Secondary" });
            if (ModelState.IsValid)
            {
                await _employeeEducationRepository.UpdateEmployeeEducation(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee Lanuage............................................

        public async Task<IActionResult> CreateEmployeeLanguage(bool isSuccess = false)
        {
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");
            ViewBag.Fluency = new SelectList(new List<string> { "Writing", "Speaking", "Reading" });
            ViewBag.Competency = new SelectList(new List<string> { "Poor", "Basic", "Good" , "Excellent" });
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeLanguage(EmployeeLanguageModel model)
        {
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");
            ViewBag.Fluency = new SelectList(new List<string> { "Writing", "Speaking", "Reading" });
            ViewBag.Competency = new SelectList(new List<string> { "Poor", "Basic", "Good", "Excellent" });

            if (ModelState.IsValid)
            {

                int id = await _employeeLanguageRepository.CreateEmployeeLanguage(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeLanguage(int id, bool isSuccess = false)
        {
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");
            ViewBag.Fluency = new SelectList(new List<string> { "Writing", "Speaking", "Reading" });
            ViewBag.Competency = new SelectList(new List<string> { "Poor", "Basic", "Good", "Excellent" });
            
            var obj = await _employeeLanguageRepository.FindEmployeeLanguage(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.LanguageId = obj.LanguageId;
            data.Competency = obj.Competency;
            data.Fluency = obj.Fluency;
            data.Comments = obj.Comments;
            


            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeLanguage(EmployeeLanguageModel model)
        {

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");
            ViewBag.Fluency = new SelectList(new List<string> { "Writing", "Speaking", "Reading" });
            ViewBag.Competency = new SelectList(new List<string> { "Poor", "Basic", "Good", "Excellent" });
            if (ModelState.IsValid)
            {
                await _employeeLanguageRepository.UpdateEmployeeLanguage(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }


        //.....................Employee Skill............................................

        public async Task<IActionResult> CreateEmployeeSkill(bool isSuccess = false)
        {
            ViewBag.Skill = new SelectList(await _skillRepository.GetSkill(),"Id" , "Name" );
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeSkill(EmployeeSkillModel model)
        {
            ViewBag.Skill = new SelectList(await _skillRepository.GetSkill(), "Id", "Name");

            if (ModelState.IsValid)
            {

                int id = await _employeeSkillRepository.CreateEmployeeSkill(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeSkill(int id, bool isSuccess = false)
        {
            ViewBag.Skill = new SelectList(await _skillRepository.GetSkill(), "Id", "Name");
            var obj = await _employeeSkillRepository.FindEmployeeSkill(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.SkillId = obj.SkillId;
            data.YearOfExperience = obj.YearOfExperience;
            data.Comments = obj.Comments;


            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeSkill(EmployeeSkillModel model)
        {
            ViewBag.Skill = new SelectList(await _skillRepository.GetSkill(), "Id", "Name");
            if (ModelState.IsValid)
            {
                await _employeeSkillRepository.UpdateEmployeeSkill(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }

        //.....................Employee License............................................

        public async Task<IActionResult> CreateEmployeeLicense(bool isSuccess = false)
        {
            ViewBag.License = new SelectList(await _licenseRepository.GetLicense(), "Id", "Name");
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeLicense(EmployeeLicenseModel model)
        {
            ViewBag.License = new SelectList(await _licenseRepository.GetLicense(), "Id", "Name");

            if (ModelState.IsValid)
            {

                int id = await _employeeLicenseRepository.CreateEmployeeLicense(model);
                if (id > 0)
                {
                    ViewBag.isSuccess = true;

                    return RedirectToAction(nameof(Index), new { isSuccess = true });
                }
            }
            return View();
        }
        public async Task<IActionResult> EditEmployeeLicense(int id, bool isSuccess = false)
        {
            ViewBag.License = new SelectList(await _licenseRepository.GetLicense(), "Id", "Name");
            var obj = await _employeeLicenseRepository.FindEmployeeLicense(id);
            ViewBag.isSuccess = isSuccess;


            dynamic data = new ExpandoObject();
            data.Id = obj.Id;
            data.LicenseId= obj.LicenseId;
            data.LicenseNumber = obj.LicenseNumber;
            data.Comments = obj.Comments;
            data.IssuedDate = obj.IssuedDate;
            data.ExpiryDate = obj.ExpiryDate;


            ViewBag.Data = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeLicense(EmployeeLicenseModel model)
        {
            ViewBag.License = new SelectList(await _licenseRepository.GetLicense(), "Id", "Name");
            if (ModelState.IsValid)
            {
                await _employeeLicenseRepository.UpdateEmployeeLicense(model);
                ViewBag.isSuccess = true;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
