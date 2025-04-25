using AutoMapper;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Application.Wrappers;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;

namespace TscLoanManagement.TSCDB.Application.Features.Dealers
{
    public class DealerDetailsService : IDealerDetailsService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<BorrowerDetails> _borrowerRepo;
        private readonly IGenericRepository<GuarantorDetails> _guarantorRepo;
        private readonly IGenericRepository<ChequeDetails> _chequeRepo;
        private readonly IGenericRepository<SecurityDepositDetails> _securityRepo;

        public DealerDetailsService(
            IMapper mapper,
            IGenericRepository<BorrowerDetails> borrowerRepo,
            IGenericRepository<GuarantorDetails> guarantorRepo,
            IGenericRepository<ChequeDetails> chequeRepo,
            IGenericRepository<SecurityDepositDetails> securityRepo)
        {
            _mapper = mapper;
            _borrowerRepo = borrowerRepo;
            _guarantorRepo = guarantorRepo;
            _chequeRepo = chequeRepo;
            _securityRepo = securityRepo;
        }

        public async Task<BorrowerDetailsDto> SubmitBorrowerDetailsAsync(BorrowerDetailsDto dto)
        {
            var entity = _mapper.Map<BorrowerDetails>(dto);
            await _borrowerRepo.AddAsync(entity);
            return _mapper.Map<BorrowerDetailsDto>(entity);
        }

        public async Task<GuarantorDetailsDto> SubmitGuarantorDetailsAsync(GuarantorDetailsDto dto)
        {
            var entity = _mapper.Map<GuarantorDetails>(dto);
            await _guarantorRepo.AddAsync(entity);
            return _mapper.Map<GuarantorDetailsDto>(entity);
        }

        public async Task<ChequeDetailsDto> SubmitChequeDetailsAsync(ChequeDetailsDto dto)
        {
            var entity = _mapper.Map<ChequeDetails>(dto);
            await _chequeRepo.AddAsync(entity);
            return _mapper.Map<ChequeDetailsDto>(entity);
        }

        public async Task<SecurityDepositDetailsDto> SubmitSecurityDepositDetailsAsync(SecurityDepositDetailsDto dto)
        {
            var entity = _mapper.Map<SecurityDepositDetails>(dto);
            await _securityRepo.AddAsync(entity);
            return _mapper.Map<SecurityDepositDetailsDto>(entity);
        }
        public async Task<ApiResponse<string>> SubmitFullDealerDetailsAsync(DealerFullDetailsDto dto)
        {
            try
            {
                var borrower = _mapper.Map<BorrowerDetails>(dto.BorrowerDetails);
                var guarantor = _mapper.Map<GuarantorDetails>(dto.GuarantorDetails);
                var cheque = _mapper.Map<ChequeDetails>(dto.ChequeDetails);
                var security = _mapper.Map<SecurityDepositDetails>(dto.SecurityDepositDetails);

                await _borrowerRepo.AddAsync(borrower);
                await _guarantorRepo.AddAsync(guarantor);
                await _chequeRepo.AddAsync(cheque);
                await _securityRepo.AddAsync(security);

                return new ApiResponse<string> { Success = true, Message = "Dealer details saved successfully." };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

    }
}
