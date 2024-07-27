using ExamenPOO2.API.Dtos.Amortization;

namespace ExamenPOO2.API.Dtos.Loan
{
    public class LoanDto
    {
        public string Message { get; set; }
        public List<AmortizationDto> AmortizationPlan { get; set; }
    }
}
