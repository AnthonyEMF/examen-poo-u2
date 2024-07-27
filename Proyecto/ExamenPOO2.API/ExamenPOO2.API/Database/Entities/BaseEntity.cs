using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPOO2.API.Database.Entities
{
	public class BaseEntity
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }
	}
}
