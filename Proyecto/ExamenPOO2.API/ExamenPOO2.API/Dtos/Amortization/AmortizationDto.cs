using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPOO2.API.Dtos.Amortization
{
	public class AmortizationDto
	{
		public int InstallmentNumber { get; set; }
		public DateTime PaymentDate { get; set; }
		public int Days { get; set; }
		public double Interest { get; set; }
		public double Principal { get; set; }
		public double LevelPaymentWithoutSVSD { get; set; }
		public double LevelPaymentWithSVSD { get; set; }
		public double PrincipalBalance { get; set; }
	}
}
