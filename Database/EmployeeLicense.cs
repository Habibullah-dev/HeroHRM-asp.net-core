using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeLicense
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LicenseId { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }


        public Employee Employee { get; set; }
        public License License { get; set; }
    }
}
