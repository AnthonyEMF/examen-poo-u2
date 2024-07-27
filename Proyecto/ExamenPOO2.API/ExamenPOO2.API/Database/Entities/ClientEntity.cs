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
	}
}
