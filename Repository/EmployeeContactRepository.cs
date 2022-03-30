using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeContactRepository : IEmployeeContactRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeContactRepository(HeroHRMContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeContact(EmployeeContactModel model)
        {
            var newEmployeeContact = new EmployeeContactDetails()
            {
                HomeTelephone = model.HomeTelephone,
                WorkTelephone = model.WorkTelephone,
                Mobile = model.Mobile,
                WorkEmail = model.WorkEmail,
                OtherEmail = model.OtherEmail,
                Phone = model.Phone,
                Email = model.Email,
                Fax = model.Fax,
                Address = model.Address,
                State = model.State,
                City = model.City,
                Country = model.Country,
                ZipCode = model.ZipCode,
                EmployeeId = model.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.EmployeeContactDetails.AddAsync(newEmployeeContact);
            await _context.SaveChangesAsync();

            return newEmployeeContact.Id;

        }


        public async Task DeleteEmployeeContact(int id)
        {
            var foundEmployeeContact = await _context.EmployeeContactDetails.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployeeContact != null)
            {
                _context.Remove(foundEmployeeContact);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeContactModel> FindEmployeeContact(int id)
        {
            return await _context.EmployeeContactDetails
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeContactModel()
                 {
                     Id = x.Id,
                     HomeTelephone = x.HomeTelephone,
                     Mobile = x.Mobile,
                     Email = x.Email,
                     WorkTelephone = x.WorkTelephone,
                     Fax = x.Fax,
                     WorkEmail = x.WorkEmail,
                     OtherEmail = x.OtherEmail,
                     Phone = x.Phone,
                     Address = x.Address,
                     State = x.State,
                     City = x.City,
                     Country = x.Country,
                     ZipCode = x.ZipCode,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeContactModel> FindEmployeeContactByEmployeeId(int employee_id)
        {
            return await _context.EmployeeContactDetails
                 .Where(x => x.EmployeeId == employee_id)
                 .Select(x => new EmployeeContactModel()
                 {
                     Id = x.Id,
                     HomeTelephone = x.HomeTelephone,
                     WorkTelephone = x.WorkTelephone,
                     Mobile = x.Mobile,
                     Email = x.Email,
                     Fax = x.Fax,
                     WorkEmail = x.WorkEmail,
                     OtherEmail = x.OtherEmail,
                     Phone = x.Phone,
                     Address = x.Address,
                     State = x.State,
                     City = x.City,
                     Country = x.Country,
                     ZipCode = x.ZipCode,
                     EmployeeId = x.EmployeeId,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,

                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeContact(EmployeeContactModel model)
        {
            var updatedEmployee = await _context.EmployeeContactDetails.FindAsync(model.Id);

            updatedEmployee.Id = model.Id;
            updatedEmployee.HomeTelephone = model.HomeTelephone;
            updatedEmployee.Mobile = model.Mobile;
            updatedEmployee.WorkEmail = model.WorkEmail;
            updatedEmployee.WorkTelephone = model.WorkTelephone;
            updatedEmployee.Email = model.Email;
            updatedEmployee.Fax = model.Fax;
            updatedEmployee.OtherEmail = model.OtherEmail;
            updatedEmployee.Phone = model.Phone;
            updatedEmployee.Address = model.Address;
            updatedEmployee.State = model.State;
            updatedEmployee.City = model.City;
            updatedEmployee.Country = model.Country;
            updatedEmployee.ZipCode = model.ZipCode;
            updatedEmployee.UpdatedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }
    }
}
