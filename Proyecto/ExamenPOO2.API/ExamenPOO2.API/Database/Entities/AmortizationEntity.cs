using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPOO2.API.Database.Entities
{
	[Table("amortizations", Schema = "dbo")]
	public class AmortizationEntity : BaseEntity
	{
		[Column("installment_number")]
        public int InstallmentNumber { get; set; }

		[Column("payment_date")]
        public DateTime PaymentDate { get; set; }

		[Column("days")]
        public int Days { get; set; }

		[Column("interest")]
        public int Interest { get; set; }

		[Column("principal")]
        public int Principal { get; set; }

		[Column("levelpayment_without_SVSD")]
        public int LevelPaymentWithoutSVSD { get; set; }

		[Column("levelpayment_with_SVSD")]
		public int LevelPaymentWithSVSD { get; set; }

		[Column("principal_balance")]
        public int PrincipalBalance { get; set; }

		public virtual IEnumerable<LoanEntity> Loan { get; set; }
	}
}
