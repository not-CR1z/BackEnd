using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
	public class Pregunta
	{
		public Int32 Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(100)")]
		public String Descripcion { get; set; }

		public Int32 CuestionarioId { get; set; }


		public List<Respuesta> listRespuestas { get; set; }
	}
}
