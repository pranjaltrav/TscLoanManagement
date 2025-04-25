﻿namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerFullDetailsDto
    {
        public List<BorrowerDetailsDto> BorrowerDetails { get; set; }
        public List<GuarantorDetailsDto> GuarantorDetails { get; set; }
        public ChequeDetailsDto ChequeDetails { get; set; }
        public SecurityDepositDetailsDto SecurityDepositDetails { get; set; }
    }
}
