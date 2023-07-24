using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Content;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
	public class LoginRepository : ILoginRepository
	{
		private readonly AplicationDbContext _context;
		public LoginRepository(AplicationDbContext context)
		{
			this._context = context;

		}

		public async Task<Usuario> ValidateUser(Usuario usuario)
		{
			var user = await this._context.Usuario.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Password == usuario.Password).FirstOrDefaultAsync();
			return user;
		}
	}
}
