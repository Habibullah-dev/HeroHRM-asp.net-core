using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeJobRepository : IEmployeeJobRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeJobRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeJob(EmployeeJobModel model)
        {
            var newEmployeeJob = new EmployeeJob()
            {
                JobTitleId = model.JobTitleId,
                EmploymentStatusId = model.EmploymentStatusId,
                JobCategoryId = model.JobCategoryId,
                CompanyBranchId = model.CompanyBranchId,
                DepartmentId = model.DepartmentId,
                ContractStart = model.ContractStart,
                ContractEnd = model.ContractEnd,
                EmployeeId = model.EmployeeId,
                JoinedDate = model.JoinedDate,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeJobs.AddAsync(newEmployeeJob);
            await _context.SaveChangesAsync();

            return newEmployeeJob.Id;
        }

        public async Task DeleteEmployeeJob(int id)
        {
            var foundEmployeeJob = await _context.EmployeeJobs.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeJob != null)
            {
                _context.Remove(foundEmployeeJob);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeJobModel> FindEmployeeJob(int id)
        {
            return await _context.EmployeeJobs
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeJobModel()
                 {
                     Id = x.Id,
                     JobTitleId = x.JobTitleId,
                     EmploymentStatusId = x.EmploymentStatusId,
                     JobCategoryId = x.JobCategoryId,
                     ContractStart = x.ContractStart,
                     JoinedDate = x.JoinedDate,
                     ContractEnd = x.ContractEnd,
                     DepartmentId = x.DepartmentId,
                     EmployeeId = x.EmployeeId,
                     CompanyBranchId = x.CompanyBranchId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeJobModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeJobs
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeJobModel()
                 {
                     Id = x.Id,
                     JobTitleId = x.JobTitleId,
                     EmploymentStatusId = x.EmploymentStatusId,
                     JobCategoryId = x.JobCategoryId,
                     ContractStart = x.ContractStart,
                     EmploymentStatus = x.EmploymentStatus.Name,
                     JobTitle = x.JobTitle.Title,
                     JobCategory = x.JobCategories.Name,
                     Department = x.Department.Name,
                     CompanyBranch = x.CompanyBranch.Name,
                     JoinedDate = x.JoinedDate,
                     ContractEnd = x.ContractEnd,
                     DepartmentId = x.DepartmentId,
                     EmployeeId = x.EmployeeId,
                     CompanyBranchId = x.CompanyBranchId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeJob(EmployeeJobModel model)
        {
            var updated = await _context.EmployeeJobs.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.JobCategoryId = model.JobCategoryId;
            updated.EmploymentStatusId = model.EmploymentStatusId;
            updated.JobTitleId = model.JobCategoryId;
            updated.ContractEnd = model.ContractEnd;
            updated.JoinedDate = model.JoinedDate;
            updated.ContractStart = model.ContractStart;
            updated.DepartmentId = model.DepartmentId;
            updated.CompanyBranchId = model.CompanyBranchId;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
