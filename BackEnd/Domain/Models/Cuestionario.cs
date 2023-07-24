using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
	public class Cuestionario
	{
		public Int32 Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(100)")]
		public String Nombre { get; set; }

		[Required]
		[Column(TypeName = "varchar(150)")]
		public String Descripcion { get; set; }


		public DateTime FechaCreacion { get; set; }

		public Int32 Activo { get; set; }

		public Int32 UsuarioId { get; set; }

		public List<Pregunta> listPreguntas { get; set; }

	}
}
