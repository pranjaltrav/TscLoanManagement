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
                if (dto.BorrowerDetails != null && dto.BorrowerDetails.Any())
                {
                    foreach (var borrowerDto in dto.BorrowerDetails)
                    {
                        var borrower = _mapper.Map<BorrowerDetails>(borrowerDto);
                        await _borrowerRepo.AddAsync(borrower);
                    }
                }

                if (dto.GuarantorDetails != null && dto.GuarantorDetails.Any())
                {
                    foreach (var guarantorDto in dto.GuarantorDetails)
                    {
                        var guarantor = _mapper.Map<GuarantorDetails>(guarantorDto);
                        await _guarantorRepo.AddAsync(guarantor);
                    }
                }

                if (dto.ChequeDetails != null && dto.ChequeDetails.Any())
                {
                    foreach (var chequeDto in dto.ChequeDetails)
                    {
                        var cheque = _mapper.Map<ChequeDetails>(chequeDto);
                        await _chequeRepo.AddAsync(cheque);
                    }
                }

                if (dto.SecurityDepositDetails != null && dto.SecurityDepositDetails.Any())
                {
                    foreach (var securityDto in dto.SecurityDepositDetails)
                    {
                        var security = _mapper.Map<SecurityDepositDetails>(securityDto);
                        await _securityRepo.AddAsync(security);
                    }
                }

                return new ApiResponse<string>("Dealer details saved successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>($"Error: {ex.Message}", false);
            }
        }


    }
}
