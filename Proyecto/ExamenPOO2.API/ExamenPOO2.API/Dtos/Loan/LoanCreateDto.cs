using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPOO2.API.Dtos.Loan
{
	public class LoanCreateDto
	{
		public string Name { get; set; }
		public string IdentityNumber { get; set; }
		public double LoanAmount { get; set; }
		public double CommissionRate { get; set; }
		public double InterestRate { get; set; }
		public int Term { get; set; }
		public DateTime DisbursementDate { get; set; }
		public DateTime FirstPaymentDate { get; set; }
	}
}
