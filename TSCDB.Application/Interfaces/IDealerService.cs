using TscLoanManagement.TSCDB.Application.DTOs;

namespace TscLoanManagement.TSCDB.Application.Interfaces
{
    public interface IDealerService
    {
        Task<IEnumerable<DealerDto>> GetAllDealersAsync();
        Task<DealerDto> GetDealerByIdAsync(int id);
        Task<DealerDto> CreateDealerAsync(DealerDto dealerDto);
        Task UpdateDealerAsync(DealerDto dealerDto);
        Task DeleteDealerAsync(int id);
    }
}
