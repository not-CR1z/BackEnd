using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
	public class Usuario
	{
		public Int32 Id { get; set; }
		[Required]
		[Column(TypeName = "varchar(20)")]
		public String NombreUsuario { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public String Password { get; set; }
	}
}
