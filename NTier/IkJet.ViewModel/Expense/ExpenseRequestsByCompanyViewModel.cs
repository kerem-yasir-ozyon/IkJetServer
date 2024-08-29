using IkJet.Common.Enums;
using IkJet.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.ViewModel.Expense
{
    public class ExpenseRequestsByCompanyViewModel:BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public double Amount { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public string? ImageName { get; set; }

		public ApprovalStatus? ApprovalStatus { get; set; }


		public int AppUserId { get; set; }
        public AppUserViewModel? AppUser { get; set; }
    }
}
