using AutoMapper;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Enums;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;

namespace TscLoanManagement.TSCDB.Application.Features.Dealers
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IMapper _mapper;

        public DealerService(IDealerRepository dealerRepository, IMapper mapper)
        {
            _dealerRepository = dealerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DealerDto>> GetAllDealersAsync()
        {
            var dealers = await _dealerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DealerDto>>(dealers);
        }

        public async Task<DealerDto> GetDealerByIdAsync(int id)
        {
            var dealer = await _dealerRepository.GetDealerByUserIdAsync(id);
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task<DealerDto> CreateDealerAsync(DealerDto dealerDto)
        {
            var dealer = _mapper.Map<Dealer>(dealerDto);
            dealer.RegisteredDate = DateTime.UtcNow;
            dealer.IsActive = true;

            await _dealerRepository.AddAsync(dealer);
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task UpdateDealerAsync(DealerDto dealerDto)
        {
            var dealer = await _dealerRepository.GetByIdAsync(dealerDto.Id);
            if (dealer == null)
                throw new ApplicationException($"Dealer with ID {dealerDto.Id} not found");

            _mapper.Map(dealerDto, dealer);
            await _dealerRepository.UpdateAsync(dealer);
        }

        public async Task DeleteDealerAsync(int id)
        {
            var dealer = await _dealerRepository.GetByIdAsync(id);
            if (dealer == null)
                throw new ApplicationException($"Dealer with ID {id} not found");

            dealer.IsActive = false;
            await _dealerRepository.UpdateAsync(dealer);
        }

        public async Task<bool> UpdateDealerStatusAsync(UpdateDealerStatusDto dto)
        {
            var dealer = await _dealerRepository.GetByIdAsync(dto.DealerId);
            if (dealer == null)
                throw new KeyNotFoundException("Dealer not found");

            dealer.Status = dto.NewStatus;

            if (dto.NewStatus == DealerStatus.Rejected)
            {
                if (string.IsNullOrEmpty(dto.RejectionReason))
                    throw new ArgumentException("Rejection reason is required when status is Rejected");

                dealer.RejectionReason = dto.RejectionReason;
            }
            else
            {
                dealer.RejectionReason = null; // Clear if not rejected
            }

            await _dealerRepository.UpdateAsync(dealer);
            return true;
        }

    }

}
