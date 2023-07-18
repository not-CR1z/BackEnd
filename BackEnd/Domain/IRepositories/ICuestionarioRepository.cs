using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
	public interface ICuestionarioRepository
	{
		Task CreateCuestionario(Cuestionario cuestionario);
	}
}
