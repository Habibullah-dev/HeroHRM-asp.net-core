using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class PayGrades
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
