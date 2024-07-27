using ExamenPOO2.API.Dtos.Common;
using ExamenPOO2.API.Dtos.Loan;
using ExamenPOO2.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenPOO2.API.Controllers
{
	[ApiController]
	[Route("api/loans")]
	public class LoansController : ControllerBase
	{
		private readonly ILoansService _loansService;

		public LoansController(ILoansService loansService)
        {
			this._loansService = loansService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResponseDto<LoanDto>>> Get(Guid id)
		{
			var response = await _loansService.GetAmortizationPlanByIdAsync(id);

			return StatusCode(response.StatusCode, response);
		}

		[HttpPost]
		public async Task<ActionResult<ResponseDto<LoanDto>>> Create(LoanCreateDto dto)
		{
			var response = await _loansService.CreateAmortizationPlanAsync(dto);

			return StatusCode(response.StatusCode, response);
		}
	}
}
