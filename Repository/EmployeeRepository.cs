using HeroHRM.Database;
using HeroHRM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HeroHRMContext _context = null;
        public EmployeeRepository(HeroHRMContext context )
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetEmployee()
        {
            return await _context.Employees
                 .Select(x => new EmployeeModel()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     MiddleName = x.MiddleName,
                     Gender = x.Gender,
                     UserId = x.UserId,
                     NationalityId = x.NationalityId,
                     MaritalStatus = x.MaritalStatus,
                     DateOfBirth = x.DateOfBirth,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy

                 }).ToListAsync();

        }
        public async Task<int> CreateEmployee(EmployeeModel model)
        {
            var newEmployee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Photograph = model.Photograph,
                UserId = model.UserId,
                Gender = model.Gender,
                NationalityId = model.NationalityId,
                MaritalStatus = model.MaritalStatus,
                DateOfBirth = model.DateOfBirth,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id;

        }


        public async Task DeleteEmployee(int id)
        {
            var foundEmployee = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (foundEmployee != null)
            {
                _context.Remove(foundEmployee);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<EmployeeModel> FindEmployee(int id)
        {
            return await _context.Employees
                 .Where(x => x.Id == id)
                 .Select(x => new EmployeeModel()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     UserId = x.UserId,
                     MiddleName = x.MiddleName,
                     Gender = x.Gender,
                     Photograph = x.Photograph,
                     Nationality = x.Nationality.Name,
                     NationalityId = x.NationalityId,
                     MaritalStatus = x.MaritalStatus,
                     DateOfBirth = x.DateOfBirth,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy
                   

                 }).FirstOrDefaultAsync();
        }
        public async Task<EmployeeModel> FindEmployeeByuserID(string id)
        {
            return await _context.Employees
                 .Where(x => x.UserId == id)
                 .Select(x => new EmployeeModel()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     UserId = x.UserId,
                     MiddleName = x.MiddleName,
                     Gender = x.Gender,
                     Photograph = x.Photograph,
                     Nationality = x.Nationality.Name,
                     NationalityId = x.NationalityId,
                     MaritalStatus = x.MaritalStatus,
                     DateOfBirth = x.DateOfBirth,
                     CreatedDate = x.CreatedDate,
                     UpdatedDate = x.UpdatedDate,
                     CreatedBy = x.CreatedBy,
                     UpdatedBy = x.UpdatedBy


                 }).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployee(EmployeeModel model)
        {
            var updatedEmployee = await _context.Employees.FindAsync(model.Id);

            updatedEmployee.Id = model.Id;
            updatedEmployee.FirstName = model.FirstName;
            updatedEmployee.LastName = model.LastName;
            updatedEmployee.UserId = model.UserId;
            updatedEmployee.MiddleName = model.MiddleName;
            updatedEmployee.Gender = model.Gender;
            updatedEmployee.NationalityId = model.NationalityId;
            updatedEmployee.MaritalStatus = model.MaritalStatus;
            updatedEmployee.DateOfBirth = model.DateOfBirth;
            updatedEmployee.UpdatedDate = model.UpdatedDate;


            await _context.SaveChangesAsync();
        }

    }
}
