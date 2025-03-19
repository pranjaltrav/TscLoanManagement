using TscLoanManagement.TSCDB.Core.Domain.Dealer;
namespace TscLoanManagement.TSCDB.Core.Domain.Loan

{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public DateTime DateOfWithdraw { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DealerId { get; set; }
        public virtual TscLoanManagement.TSCDB.Core.Domain.Dealer.Dealer Dealer { get; set; }
        public string UtrNumber { get; set; }
        public decimal ProcessingFee { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual VehicleInfo VehicleInfo { get; set; }
        public virtual BuyerInfo BuyerInfo { get; set; }
        public virtual ICollection<LoanAttachment> Attachments { get; set; }
    }
}
