using System.Formats.Asn1;
using AutoMapper;
using System.Globalization;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Core.Domain.Loan;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;
using CsvHelper;
using TscLoanManagement.TSCDB.Application.DTOs;


namespace TscLoanManagement.TSCDB.Application.Features.Loans
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public async Task<IEnumerable<LoanDto>> GetLoansByDealerIdAsync(int dealerId)
        {
            var loans = await _loanRepository.GetLoansByDealerIdAsync(dealerId);
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public async Task<LoanDto> GetLoanByIdAsync(int id)
        {
            var loan = await _loanRepository.GetLoanWithDetailsAsync(id);
            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<LoanDto> CreateLoanAsync(LoanDto loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            loan.CreatedDate = DateTime.UtcNow;
            loan.IsActive = true;
            loan.LoanNumber = GenerateLoanNumber();

            await _loanRepository.AddAsync(loan);
            return _mapper.Map<LoanDto>(loan);
        }

        public async Task UpdateLoanAsync(LoanDto loanDto)
        {
            var loan = await _loanRepository.GetLoanWithDetailsAsync(loanDto.Id);
            if (loan == null)
                throw new ApplicationException($"Loan with ID {loanDto.Id} not found");

            _mapper.Map(loanDto, loan);
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan == null)
                throw new ApplicationException($"Loan with ID {id} not found");

            loan.IsActive = false;
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task<bool> BulkUploadLoansAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ApplicationException("File is empty");

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (fileExtension != ".csv" && fileExtension != ".xlsx")
                throw new ApplicationException("Only CSV and Excel files are supported");

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<LoanImportDto>().ToList();
                    foreach (var record in records)
                    {
                        var loan = new Loan
                        {
                            LoanNumber = record.LoanNumber ?? GenerateLoanNumber(),
                            DateOfWithdraw = record.DateOfWithdraw,
                            Amount = record.Amount,
                            InterestRate = record.InterestRate,
                            DealerId = record.DealerId,
                            UtrNumber = record.UtrNumber,
                            ProcessingFee = record.ProcessingFee,
                            DueDate = record.DueDate,
                            IsActive = true,
                            CreatedDate = DateTime.UtcNow,
                            VehicleInfo = new VehicleInfo
                            {
                                Make = record.VehicleMake,
                                Model = record.VehicleModel,
                                RegistrationNumber = record.VehicleRegistrationNumber,
                                Year = record.VehicleYear,
                                ChassisNumber = record.VehicleChassisNumber,
                                EngineNumber = record.VehicleEngineNumber,
                                Value = record.VehicleValue
                            },
                            BuyerInfo = new BuyerInfo
                            {
                                Name = record.BuyerName,
                                PhoneNumber = record.BuyerPhoneNumber,
                                Email = record.BuyerEmail,
                                Address = record.BuyerAddress,
                                IdentificationType = record.BuyerIdentificationType,
                                IdentificationNumber = record.BuyerIdentificationNumber,
                                BuyerSource = record.BuyerSource
                            }
                        };

                        await _loanRepository.AddAsync(loan);
                    }
                }
            }

            return true;
        }

        public async Task<decimal> CalculateInterestTillDateAsync(int loanId, DateTime? tillDate = null)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);
            if (loan == null)
                throw new ApplicationException($"Loan with ID {loanId} not found");

            var endDate = tillDate ?? DateTime.UtcNow;
            var days = (endDate - loan.DateOfWithdraw).Days;
            if (days < 0) days = 0;

            // Calculate interest based on daily rate
            var dailyRate = loan.InterestRate / 365;
            var interest = loan.Amount * (decimal)days * dailyRate / 100;

            return Math.Round(interest, 2);
        }

        private string GenerateLoanNumber()
        {
            // Generate a unique loan number
            return $"LOAN-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }
    }
 }
