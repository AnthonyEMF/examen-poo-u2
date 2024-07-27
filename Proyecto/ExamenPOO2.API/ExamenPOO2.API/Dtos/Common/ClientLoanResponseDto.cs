using ExamenPOO2.API.Dtos.Amortization;

namespace ExamenPOO2.API.Dtos.Common
{
	public class ClientLoanResponseDto
	{
		public Guid ClientId { get; set; }
		public string Name { get; set; }
		public string IdentityNumber { get; set; }
		public double LoanAmount { get; set; }
		public List<AmortizationDto> AmortizationPlan { get; set; }
	}
}
