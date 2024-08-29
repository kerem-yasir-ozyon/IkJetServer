using IkJet.Common.Enums;
using IkJet.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.ViewModel.WorkOff
{
    public class WorkOffViewModel: BaseViewModel
    {

        public WorkOfType WorkOfType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequestedLeaveDay { get; set; }

		public ApprovalStatus? ApprovalStatus { get; set; }


		public int AppUserId { get; set; }
        public AppUserViewModel? AppUser { get; set; }
    }
}
