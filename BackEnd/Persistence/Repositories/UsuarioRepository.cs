using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Content;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly AplicationDbContext _context;
		public UsuarioRepository(AplicationDbContext context)
		{
			this._context = context;
		}

		public async Task SaveUser(Usuario usuario)
		{
			this._context.Add(usuario);
			await this._context.SaveChangesAsync();
		}

		public async Task<Boolean> ValidateExistence(Usuario usuario)
		{
			var validateExistence = await this._context.Usuario.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
			return validateExistence;
		}

		public async Task<Usuario> ValidatePassword(Int32 idUsuario, String passwordAnterior)
		{
			var usuario = await this._context.Usuario.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
			return usuario;
		}

		public async Task UpdatePassword(Usuario usuario)
		{
			this._context.Update(usuario);
			await this._context.SaveChangesAsync();
		}
	}
}
