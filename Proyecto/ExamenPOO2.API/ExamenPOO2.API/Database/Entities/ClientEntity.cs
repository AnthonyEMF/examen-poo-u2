using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPOO2.API.Database.Entities
{
	[Table("clients", Schema = "dbo")]
	public class ClientEntity : BaseEntity
	{
		[Required(ErrorMessage = "Es requerido ingresar el campo de name.")]
		[Column("name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de identify number.")]
		[Column("identify_number")]
		public string IdentityNumber { get; set; }

		public ICollection<LoanEntity> Loans { get; set; }
	}
}
