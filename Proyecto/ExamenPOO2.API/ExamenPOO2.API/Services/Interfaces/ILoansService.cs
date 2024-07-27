using ExamenPOO2.API.Dtos.Common;
using ExamenPOO2.API.Dtos.Loan;

namespace ExamenPOO2.API.Services.Interfaces
{
	public interface ILoansService
	{
		Task<ResponseDto<LoanDto>> CreateAmortizationPlanAsync(LoanCreateDto dto);
		Task<ResponseDto<LoanDto>> GetAmortizationPlanByIdAsync(Guid id);
	}
}
