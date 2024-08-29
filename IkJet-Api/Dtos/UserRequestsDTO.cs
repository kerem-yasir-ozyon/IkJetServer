using IkJet.Entities.Concrete;

namespace IkJet_Api.Dtos
{
    public class UserRequestsDTO
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<WorkOff> WorkOffs { get; set; }
        public IEnumerable<Prepayment> Prepayments { get; set; }
    }
}
