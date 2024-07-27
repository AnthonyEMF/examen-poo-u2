using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPOO2.API.Database.Entities
{
	[Table("amortizations", Schema = "dbo")]
	public class AmortizationEntity : BaseEntity
	{
		[Column("loan_id")]
		public Guid LoanId { get; set; }
		[ForeignKey(nameof(LoanId))]
		public LoanEntity Loan { get; set; }

		[Column("installment_number")]
        public int InstallmentNumber { get; set; }

		[Column("payment_date")]
        public DateTime PaymentDate { get; set; }

		[Column("days")]
        public int Days { get; set; }

		[Column("interest")]
        public double Interest { get; set; }

		[Column("principal")]
        public double Principal { get; set; }

		[Column("levelpayment_without_SVSD")]
        public double LevelPaymentWithoutSVSD { get; set; }

		[Column("levelpayment_with_SVSD")]
		public double LevelPaymentWithSVSD { get; set; }

		[Column("principal_balance")]
        public double PrincipalBalance { get; set; }
	}
}
