using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeJob
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public int EmploymentStatusId { get; set; }
        public int JobCategoryId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyBranchId { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
        public JobTitle JobTitle { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public JobCategories JobCategories { get; set; }
        public Department Department { get; set; }
        public CompanyBranch CompanyBranch { get; set; }


    }
}
