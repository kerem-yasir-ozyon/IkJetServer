using IkJet.ViewModel.Expense;
using IkJet.ViewModel.Prepayment;
using IkJet.ViewModel.WorkOff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.ViewModel.AppUser
{
    public class AppUserViewModel
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

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
        public string? ConfirmationEmail { get; set; }

        public IEnumerable<ExpenseViewModel>? Expenses { get; set; }
        public IEnumerable<PrepaymentViewModel>? Prepayments { get; set; }
        public IEnumerable<WorkOffViewModel>? WorkOffs { get; set; }


    }
}
