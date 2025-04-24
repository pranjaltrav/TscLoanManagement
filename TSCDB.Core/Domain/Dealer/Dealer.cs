using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Domain.Loan;

namespace TscLoanManagement.TSCDB.Core.Domain.Dealer
{
    public class Dealer
    {
        public int Id { get; set; }
        public string DealerCode { get; set; }
        public string LoanProposalNo { get; set; }
        public string DealershipName { get; set; }
        public string DealershipPAN { get; set; }
        public string Status { get; set; }
        public DateTime DateOfIncorporation { get; set; }
        public string Entity { get; set; }
        public string GSTNo { get; set; }
        public string MSMERegistrationNo { get; set; }
        public string MSMEType { get; set; } // Medium, Small, Micro

        public string ContactNo { get; set; }
        public string AlternativeContactNo { get; set; }
        public string EmailId { get; set; }
        public string AlternativeEmailId { get; set; }
        public string ShopAddress { get; set; }
        public string ParkingYardAddress { get; set; }

        public string RelationshipManager { get; set; }

        public bool IsActive { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TscLoanManagement.TSCDB.Core.Domain.Loan.Loan> Loans { get; set; }

        public ICollection<ChequeDetails> ChequeDetails { get; set; }
        public ICollection<BorrowerDetails> BorrowerDetails { get; set; }
        public ICollection<GuarantorDetails> GuarantorDetails { get; set; }
        public ICollection<SecurityDepositDetails> SecurityDepositDetails { get; set; }

        public virtual ICollection<DocumentUpload> DocumentUploads { get; set; }

    }
}
