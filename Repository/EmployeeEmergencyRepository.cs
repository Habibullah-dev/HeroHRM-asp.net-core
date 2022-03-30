using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeEmergencyRepository : IEmployeeEmergencyRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeEmergencyRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeEmergency(EmployeeEmergencyModel model)
        {
            var newEmployeeEmergency = new EmployeeEmergencyContact()
            {
                HomeTelephone = model.HomeTelephone,
                Mobile = model.Mobile,
                Name = model.Name,
                Relationship = model.Relationship,
                WorkTelephone = model.WorkTelephone,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeEmergencyContacts.AddAsync(newEmployeeEmergency);
            await _context.SaveChangesAsync();

            return newEmployeeEmergency.Id;

        }


        public async Task DeleteEmployeeEmergency(int id)
        {
            var foundEmployeeEmergency = await _context.EmployeeEmergencyContacts.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeEmergency != null)
            {
                _context.Remove(foundEmployeeEmergency);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeEmergencyModel> FindEmployeeEmergency(int id)
        {
            return await _context.EmployeeEmergencyContacts
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeEmergencyModel()
                 {
                     Id = x.Id,
                     HomeTelephone = x.HomeTelephone,
                     Mobile = x.Mobile,
                     Name = x.Name,
                     Relationship = x.Relationship,
                     WorkTelephone = x.WorkTelephone,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<List<EmployeeEmergencyModel>> FindEmployeeEmergencyByEmployeeID(int id)
        {
            return await _context.EmployeeEmergencyContacts
                 .Where(x => x.EmployeeId == id)
                 .Select(x => new EmployeeEmergencyModel()
                 {
                     Id = x.Id,
                     HomeTelephone = x.HomeTelephone,
                     Mobile = x.Mobile,
                     Name = x.Name,
                     Relationship = x.Relationship,
                     WorkTelephone = x.WorkTelephone,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).ToListAsync();
        }

        public async Task UpdateEmployeeEmergency(EmployeeEmergencyModel model)
        {
            var updatedEmployee = await _context.EmployeeEmergencyContacts.FindAsync(model.Id);

            updatedEmployee.Id = model.Id;
            updatedEmployee.HomeTelephone = model.HomeTelephone;
            updatedEmployee.Mobile = model.Mobile;
            updatedEmployee.Name = model.Name;
            updatedEmployee.Relationship = model.Relationship;
            updatedEmployee.WorkTelephone = model.WorkTelephone;
            updatedEmployee.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
