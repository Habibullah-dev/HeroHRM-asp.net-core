using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeContactDetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int HomeTelephone { get; set; }
        public int Mobile { get; set; }
        public int WorkTelephone { get; set; }
        public string WorkEmail { get; set; }
        public string OtherEmail { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }

    }
}
