using IkJet.Common.Enums;
using IkJet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.Entities.Concrete
{
	public class WorkOff : BaseEntity
	{
        public WorkOfType WorkOfType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequestedLeaveDay { get; set; }



		public ApprovalStatus? ApprovalStatus { get; set; }
		public DateTime? RequestDate { get; set; }
		public DateTime? ResponseDate { get; set; }


		//relationships
		public int AppUserId { get; set; }
		public AppUser? AppUser { get; set; }


	}
}
