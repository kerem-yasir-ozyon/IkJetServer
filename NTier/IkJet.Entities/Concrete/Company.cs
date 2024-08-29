using IkJet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.Entities.Concrete
{
	public class Company : BaseEntity
	{
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNumber { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string? ImageName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? EmployeeCount { get; set; }
        public DateTime FoundationOfYear { get; set; }
        public DateTime ConractStartDate { get; set; }
        public DateTime ConractEndDate { get; set; }
        public bool IsActive { get; set; }




        //relationships

        public IEnumerable<AppUser>? AppUsers { get; set; }










    }
}
