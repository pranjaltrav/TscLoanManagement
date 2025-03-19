using TscLoanManagement.TSCDB.Core.Domain.Authentication;

namespace TscLoanManagement.TSCDB.Core.Domain.Dealer
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal SanctionLimit { get; set; }
        public decimal ProcessingFee { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TscLoanManagement.TSCDB.Core.Domain.Loan.Loan> Loans { get; set; }

    }
}
