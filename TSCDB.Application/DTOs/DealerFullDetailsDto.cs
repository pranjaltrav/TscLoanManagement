namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerFullDetailsDto
    {
        public BorrowerDetailsDto BorrowerDetails { get; set; }
        public GuarantorDetailsDto GuarantorDetails { get; set; }
        public ChequeDetailsDto ChequeDetails { get; set; }
        public SecurityDepositDetailsDto SecurityDepositDetails { get; set; }
    }
}
