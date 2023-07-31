using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
	public interface ICuestionarioRepository
	{
		Task CreateCuestionario(Cuestionario cuestionario);
		Task<List<Cuestionario>> GetListCuestionarioByUser(Int32 idUsuario);
		Task<Cuestionario> GetCuestionario(Int32 idCuestionario);
	}
}
