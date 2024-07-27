using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPOO2.API.Database.Entities
{
	[Table("loans", Schema = "dbo")]
	public class LoanEntity : BaseEntity
	{
		[Column("client_id")]
		public Guid ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public ClientEntity Client { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de loan amount.")]
		[Column("loan_amount")]
		public double LoanAmount { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de commission rate.")]
		[Column("commission_rate")]
		public double CommissionRate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de interest rate.")]
		[Column("interest_rate")]
		public double InterestRate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de term.")]
		[Column("term")]
		public int Term { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de disbursement date.")]
		[Column("disbursement_date")]
		public DateTime DisbursementDate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de first payment date.")]
		[Column("first_payment_date")]
		public DateTime FirstPaymentDate { get; set; }

		public ICollection<AmortizationEntity> AmortizationPlan { get; set; }
	}
}
