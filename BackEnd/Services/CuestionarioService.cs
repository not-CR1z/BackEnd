using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
	public class CuestionarioService : ICuestionarioService
	{
		private readonly ICuestionarioRepository _cuestionarioRepository;

		public CuestionarioService(ICuestionarioRepository cuestionarioRepository)
		{
			_cuestionarioRepository = cuestionarioRepository;
		}
		public async Task CreateCuestionario(Cuestionario cuestionario)
		{
			await _cuestionarioRepository.CreateCuestionario(cuestionario);
		}
	}
}
