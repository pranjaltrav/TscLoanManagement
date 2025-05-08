using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;

namespace TscLoanManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapper;

        public DealersController(IDealerService dealerService, IMapper mapper)
        {
            _dealerService = dealerService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DealerDto>>> GetAllDealers()
        {
            var dealers = await _dealerService.GetAllDealersAsync();
            return Ok(dealers);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DealerDto>> GetDealerById(int id)
        {
            var dealer = await _dealerService.GetDealerByIdAsync(id);
            if (dealer == null)
                return NotFound();

                var dealerDto = _mapper.Map<DealerDto>(dealer);
                return Ok(dealerDto);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<DealerDto>> CreateDealer(DealerDto dealerDto)
        {
            var createdDealer = await _dealerService.CreateDealerAsync(dealerDto);
            return CreatedAtAction(nameof(GetDealerById), new { id = createdDealer.Id }, createdDealer);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateDealer(int id, [FromBody] DealerDto dealerDto)
        {
            if (id != dealerDto.Id)
                return BadRequest();

            try
            {
                await _dealerService.UpdateDealerAsync(dealerDto);
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDealer(int id)
        {
            try
            {
                await _dealerService.DeleteDealerAsync(id);
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        [AllowAnonymous] // Allowing anonymous access for now
        public async Task<ActionResult<DealerDto>> RegisterDealer([FromBody] DealerDto dealerDto)
        {
            if (dealerDto == null)
            {
                return BadRequest("Dealer data is required.");
            }

            var createdDealer = await _dealerService.CreateDealerAsync(dealerDto);
            return CreatedAtAction(nameof(GetDealerById), new { id = createdDealer.Id }, createdDealer);
        }

        [HttpPut("UpdateDealerStatus")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDealerStatus([FromBody] UpdateDealerStatusDto dto)
        {
            var result = await _dealerService.UpdateDealerStatusAsync(dto);
            return Ok(new { success = result, message = "Dealer status updated successfully." });
        }

    }
}
