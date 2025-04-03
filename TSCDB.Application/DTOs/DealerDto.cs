using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Domain.Loan;

namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerDto
    {
        public int Id { get; set; }
        public string DealerCode { get; set; }
        public string LoanProposalNo { get; set; }
        public string Name { get; set; }
        public DateTime DateOfOnboarding { get; set; }
        public string PAN { get; set; }
        public string EntityType { get; set; }
        public string Location { get; set; }
        public string RelationshipManager { get; set; }
        public string Status { get; set; }
        public decimal ROI { get; set; }
        public decimal DelayROI { get; set; }
        public decimal SanctionAmount { get; set; }
        public decimal AvailableLimit { get; set; }
        public decimal OutstandingAmount { get; set; }
        public int OverdueCount { get; set; }
        public int DocumentStatus { get; set; }
        public int StockAuditStatus { get; set; }
        public decimal PrincipalOutstanding { get; set; }
        public decimal PFReceived { get; set; }
        public decimal InterestReceived { get; set; }
        public decimal DelayInterestReceived { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal PFAcrued { get; set; }
        public decimal InterestAccrued { get; set; }
        public decimal DelayInterestAccrued { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisteredDate { get; set; }
        public decimal WaiverAmount { get; set; }
        public decimal UtilizationPercentage { get; set; }
        public int UserId { get; set; }
    }
}
