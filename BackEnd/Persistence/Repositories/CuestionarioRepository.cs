using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Content;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
	public class CuestionarioRepository : ICuestionarioRepository
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

		public async Task<List<Cuestionario>> GetListCuestionarioByUser(Int32 idUsuario)
		{
			var listCuestionario = await _context.Cuestionario.Where(x => x.Activo == 1 && x.UsuarioId == idUsuario).ToListAsync();
			return listCuestionario;
		}

		public async Task<Cuestionario> GetCuestionario(int idCuestionario)
		{
			var cuestionario = await _context.Cuestionario.Where(x => x.Id == idCuestionario && x.Activo == 1).Include(x => x.listPreguntas).ThenInclude(x => x.listRespuestas).FirstOrDefaultAsync();
			return cuestionario;
		}
	}
}
