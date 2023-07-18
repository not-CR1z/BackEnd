using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Content;

namespace BackEnd.Persistence.Repositories
{
	public class CuestionarioRepository: ICuestionarioRepository
	{
      private readonly AplicationDbContext _context;
        public CuestionarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

		public async Task CreateCuestionario(Cuestionario cuestionario)
		{
			_context.Add(cuestionario);
			await _context.SaveChangesAsync();
		}
	}
}
