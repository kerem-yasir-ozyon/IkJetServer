using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkJet.DTO.Abstract;

namespace IkJet.DTO.Concrete
{
    public class AppUserDto 
    {


        public int? Id { get; set; }
        public string? Email { get; set; }
		public string? Password { get; set; }
        public string Role { get; set; }



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

        public IEnumerable<ExpenseDto>? Expenses { get; set; }
        public IEnumerable<PrepaymentDto>? Prepayments { get; set; }
        public IEnumerable<WorkOffDto>? WorkOffs { get; set; }
    }
}
