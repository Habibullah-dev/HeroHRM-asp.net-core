using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeSupervisorRepository : IEmployeeSupervisorRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeSupervisorRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeSupervisor(EmployeeSupervisorModel model)
        {
            var newEmployeeSupervisor = new EmployeeSupervisor()
            {
                Supervisor = model.Supervisor,
                ReportingMethod = model.ReportingMethod,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeSupervisors.AddAsync(newEmployeeSupervisor);
            await _context.SaveChangesAsync();

            return newEmployeeSupervisor.Id;
        }

        public async Task DeleteEmployeeSupervisor(int id)
        {
            var foundEmployeeSupervisor = await _context.EmployeeSupervisors.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (foundEmployeeSupervisor != null)
            {
                _context.Remove(foundEmployeeSupervisor);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeSupervisorModel> FindEmployeeSupervisor(int id)
        {
            return await _context.EmployeeSupervisors
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeSupervisorModel()
                 {
                     Id = x.Id,
                     Supervisor=x.Supervisor,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeSupervisorModel> FindByEmployeeId(int id)
        {
            return await _context.EmployeeSupervisors
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeSupervisorModel()
                 {
                     Id = x.Id,
                     Supervisor = x.Supervisor,
                     ReportingMethod = x.ReportingMethod,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeSupervisor(EmployeeSupervisorModel model)
        {
            var updated = await _context.EmployeeSupervisors.FindAsync(model.Id);

            updated.Id = model.Id;
            updated.Supervisor = model.Supervisor;
            updated.EmployeeId = model.EmployeeId;
            updated.ReportingMethod = model.ReportingMethod;
            updated.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
