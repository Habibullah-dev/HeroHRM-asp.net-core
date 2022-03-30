using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeImmigration
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string DocumentType { get; set; }
        public int NationalityId { get; set; }
        public int Number { get; set; }
        public string EligibleStatus { get; set; }
        public int IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? EligibleReviewDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
        public Nationality Nationality { get; set; }
    }
}
