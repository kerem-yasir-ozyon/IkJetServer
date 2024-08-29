using IkJet.Common.Enums;
using IkJet.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DTO.Concrete
{
    public class WorkOffDto : BaseDto
    {
        public WorkOfType WorkOfType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequestedLeaveDay { get; set; }

		public ApprovalStatus ApprovalStatus { get; set; }
		public DateTime RequestDate { get; set; }
		public DateTime ResponseDate { get; set; }
		

		//relationships
		public int AppUserId { get; set; }
        public AppUserDto? AppUser { get; set; }
       

    }
}
