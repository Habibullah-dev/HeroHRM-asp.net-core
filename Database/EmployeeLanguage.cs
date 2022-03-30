using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeLanguage
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LanguageId { get; set; }
        public string Fluency { get; set; }
        public string Competency { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }


        public Employee Employee { get; set; }
        public Language Language { get; set; }
    }
}
