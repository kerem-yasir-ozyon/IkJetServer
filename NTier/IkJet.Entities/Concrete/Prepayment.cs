using IkJet.Common.Enums;
using IkJet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.Entities.Concrete
{
	public class Prepayment : BaseEntity
	{
		
        public double Amount { get; set; }
		public CurrencyType CurrencyType { get; set; }
		public string Description { get; set; }
        public PrepaymentType PrepaymentType { get; set; }


		public ApprovalStatus? ApprovalStatus { get; set; }
		public DateTime? RequestDate { get; set; }
		public DateTime? ResponseDate { get; set; }


		//relationships
		public int AppUserId { get; set; }
		public AppUser? AppUser { get; set; }


	}
}
