using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
	public interface ICuestionarioService
	{
		Task CreateCuestionario(Cuestionario cuestionario);
	}
}
