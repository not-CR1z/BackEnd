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
			this._context = context;
		}

		public async Task CreateCuestionario(Cuestionario cuestionario)
		{
			this._context.Add(cuestionario);
			await this._context.SaveChangesAsync();
		}


		public async Task<List<Cuestionario>> GetCuestionariosByUser(Int32 idUsuario)
		{
			var listCuestionario = await this._context.Cuestionario.Where(x => x.Activo == 1 && x.UsuarioId == idUsuario).ToListAsync();
			return listCuestionario;
		}

		public async Task<Cuestionario> GetCuestionario(Int32 idCuestionario)
		{
			var cuestionario = await this._context.Cuestionario.Where(x => x.Id == idCuestionario && x.Activo == 1).FirstOrDefaultAsync();
			return cuestionario;
		}
	}
}
