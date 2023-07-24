using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
	public class Respuesta
	{
		public Int32 Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public String Descripcion { get; set; }

		[Required]
		public Boolean EsCorrecta { get; set; }

		public Int32 PreguntaId { get; set; }
	}
}
