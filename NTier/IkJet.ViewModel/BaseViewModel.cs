using IkJet.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.ViewModel
{
    public abstract class BaseViewModel
    {
        public int? Id { get; set; }
        //public ApprovalStatus? ApprovalStatus { get; set; }
        public bool IsDeleted { get; set; }


    }
}
