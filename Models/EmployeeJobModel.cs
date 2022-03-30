using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeJobModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        
        [Display(Name = "Job Title")]
        public int JobTitleId { get; set; }
        public string JobTitle { get; set; }
        [Display(Name = "Employment Status")]
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        [Display(Name = "Job Category")]
        public int JobCategoryId { get; set; }
        public string JobCategory { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        [Display(Name = "Comapny Branch")]
        public int CompanyBranchId { get; set; }
        public string CompanyBranch { get; set; }
        [Display(Name = "Joind Date*")]
        [DataType(DataType.Date)]
        public DateTime? JoinedDate { get; set; }
        
        [Display(Name = "Contract Start Date*")]
        [DataType(DataType.Date)]
        public DateTime? ContractStart { get; set; }
        
        [Display(Name = "Contract End Date*")]
        [DataType(DataType.Date)]
        public DateTime? ContractEnd { get; set; }
        
        [Display(Name = "Contract End Date*")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
