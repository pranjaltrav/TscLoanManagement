namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerFullDetailsDto
    {
        public List<BorrowerDetailsDto> BorrowerDetails { get; set; }
        public List<GuarantorDetailsDto> GuarantorDetails { get; set; }
        public List<ChequeDetailsDto> ChequeDetails { get; set; }
        public List<SecurityDepositDetailsDto> SecurityDepositDetails { get; set; }
    }
}
