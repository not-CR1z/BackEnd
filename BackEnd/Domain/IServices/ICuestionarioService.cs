using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
	public interface ICuestionarioService
	{
		Task CreateCuestionario(Cuestionario cuestionario);
		Task<List<Cuestionario>> GetCuestionariosByUser(Int32 idUsuario);
		Task<Cuestionario> GetCuestionario(Int32 idCuestionario);

	}
}
