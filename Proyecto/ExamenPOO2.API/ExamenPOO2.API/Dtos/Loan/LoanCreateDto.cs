using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPOO2.API.Dtos.Loan
{
	public class LoanCreateDto
	{
		[Required(ErrorMessage = "Es requerido ingresar el campo de name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de identity number.")]
		public int IdentityNumber { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de loan amount.")]
		public int LoanAmount { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de commission rate.")]
		public int CommissionRate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de interest rate.")]
		public int InterestRate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de term.")]
		public int Term { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de disbursement date.")]
		public DateTime DisbursementDate { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de first payment date.")]
		public DateTime FirstPaymentDate { get; set; }
	}
}
