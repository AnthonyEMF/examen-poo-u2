using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPOO2.API.Dtos.Loan
{
	public class LoanDto
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
		public int IdentityNumber { get; set; }
		public int LoanAmount { get; set; }
		public int CommissionRate { get; set; }
		public int InterestRate { get; set; }
		public int Term { get; set; }
		public DateTime DisbursementDate { get; set; }
		public DateTime FirstPaymentDate { get; set; }
	}
}
