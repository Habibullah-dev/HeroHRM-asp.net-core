using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeroHRM.Database
{
    public class HeroHRMContext : IdentityDbContext
    {
        public HeroHRMContext(DbContextOptions<HeroHRMContext> options) : base(options)
        {

        }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<PayGrades> PayGrades { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<JobCategories> JobCategories { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<CompanyBranch> CompanyBranches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeContactDetails> EmployeeContactDetails { get; set; }
        public DbSet<EmployeeDependant> EmployeeDependants { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public DbSet<EmployeeImmigration> EmployeeImmigrations { get; set; }
        public DbSet<EmployeeJob> EmployeeJobs { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public DbSet<EmployeeLicense> EmployeeLicenses { get; set; }
        public DbSet<EmployeeMembership> EmployeeMemberships { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeSubordinate> EmployeeSubordinates { get; set; }
        public DbSet<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public DbSet<EmployeeWorkExperience> EmployeeWorkExperiences { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Resign> Resigns { get; set; }


    }
}
