using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPOO2.API.Dtos.Client
{
	public class ClientCreateDto
	{
		[Required(ErrorMessage = "Es requerido ingresar el campo de name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Es requerido ingresar el campo de identify number.")]
		public string IdentityNumber { get; set; }
	}
}
