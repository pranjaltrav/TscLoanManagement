﻿using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Wrappers;

namespace TscLoanManagement.TSCDB.Application.Interfaces
{
    public interface IDealerDetailsService
    {
        Task<BorrowerDetailsDto> SubmitBorrowerDetailsAsync(BorrowerDetailsDto dto);
        Task<GuarantorDetailsDto> SubmitGuarantorDetailsAsync(GuarantorDetailsDto dto);
        Task<ChequeDetailsDto> SubmitChequeDetailsAsync(ChequeDetailsDto dto);
        Task<SecurityDepositDetailsDto> SubmitSecurityDepositDetailsAsync(SecurityDepositDetailsDto dto);
        Task<ApiResponse<string>> SubmitFullDealerDetailsAsync(DealerFullDetailsDto dto);

    }
}
