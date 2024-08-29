using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.Entities.Concrete
{
	public class AppUser : IdentityUser<int>
	{
       

        public string? ImageName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TCIdentityNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string ConfirmationEmail { get; set; }



        //relationships

        public IEnumerable<Expense>? Expenses { get; set; }
        public IEnumerable<Prepayment>? Prepayments { get; set; }
        public IEnumerable<WorkOff>? WorkOffs { get; set; }


        public int? CompanyId { get; set; }
        public Company? Company { get; set; }




    }
}
