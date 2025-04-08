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

        public DealersController(IDealerService dealerService)
        {
            _dealerService = dealerService;
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

            return Ok(dealer);
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
        public async Task<ActionResult> UpdateDealer(int id, DealerDto dealerDto)
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<DealerDto>> GetDealerById(int id)
        //{
        //    var dealer = await _dealerService.GetDealerByIdAsync(id);
        //    if (dealer == null)
        //        return NotFound();

        //    return Ok(dealer);
        //}
    }
}
