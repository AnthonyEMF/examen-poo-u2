namespace ExamenPOO2.API.Dtos.Amortization
{
	public class AmortizationCreateDto
	{
		public int InstallmentNumber { get; set; }
		public DateTime PaymentDate { get; set; }
		public int Days { get; set; }
		public int Interest { get; set; }
		public int Principal { get; set; }
		public int LevelPaymentWithoutSVSD { get; set; }
		public int LevelPaymentWithSVSD { get; set; }
		public int PrincipalBalance { get; set; }
	}
}
