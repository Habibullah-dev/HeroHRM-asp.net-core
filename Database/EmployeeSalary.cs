using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PayGradeId { get; set; }
        public string PayFrequency { get; set; }
        public int CuurencyId { get; set; }
        public int Amount { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
        public PayGrades PayGrades { get; set; }
        public Currency Currency { get; set; }
    }
}
