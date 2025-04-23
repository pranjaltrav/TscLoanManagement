using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Domain.Loan;

namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerDto
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
        public string MSMEType { get; set; }

        public string ContactNo { get; set; }
        public string AlternativeContactNo { get; set; }
        public string EmailId { get; set; }
        public string AlternativeEmailId { get; set; }
        public string ShopAddress { get; set; }
        public string ParkingYardAddress { get; set; }

        public string RelationshipManager { get; set; }

        public bool IsActive { get; set; }
        public DateTime RegisteredDate { get; set; }

        public List<ChequeDetailsDto> ChequeDetails { get; set; }
        public List<BorrowerDetailsDto> BorrowerDetails { get; set; }
        public List<GuarantorDetailsDto> GuarantorDetails { get; set; }
        public List<SecurityDepositDetailsDto> SecurityDepositDetails { get; set; }
    }
}
