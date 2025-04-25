using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;

namespace TscLoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerDetailsController : ControllerBase
    {
        private readonly IDealerDetailsService _dealerDetailsService;

        public DealerDetailsController(IDealerDetailsService dealerDetailsService)
        {
            _dealerDetailsService = dealerDetailsService;
        }

        [HttpPost("borrower")]
        public async Task<IActionResult> SubmitBorrowerDetails([FromBody] BorrowerDetailsDto dto)
        {
            var result = await _dealerDetailsService.SubmitBorrowerDetailsAsync(dto);
            return Ok(result);
        }

        [HttpPost("guarantor")]
        public async Task<IActionResult> SubmitGuarantorDetails([FromBody] GuarantorDetailsDto dto)
        {
            var result = await _dealerDetailsService.SubmitGuarantorDetailsAsync(dto);
            return Ok(result);
        }

        [HttpPost("cheque")]
        public async Task<IActionResult> SubmitChequeDetails([FromBody] ChequeDetailsDto dto)
        {
            var result = await _dealerDetailsService.SubmitChequeDetailsAsync(dto);
            return Ok(result);
        }

        [HttpPost("security-deposit")]
        public async Task<IActionResult> SubmitSecurityDepositDetails([FromBody] SecurityDepositDetailsDto dto)
        {
            var result = await _dealerDetailsService.SubmitSecurityDepositDetailsAsync(dto);
            return Ok(result);
        }

        [HttpPost("full-details")]
        public async Task<IActionResult> SubmitFullDealerDetails([FromBody] DealerFullDetailsDto dto)
        {
            var response = await _dealerDetailsService.SubmitFullDealerDetailsAsync(dto);
            if (!response.Success)
                return StatusCode(500, response);

            return Ok(response);
        }

    }
}
