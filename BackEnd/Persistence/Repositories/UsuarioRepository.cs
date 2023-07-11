using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Content;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
	public class UsuarioRepository: IUsuarioRepository
	{
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

      public async Task SaveUser(Usuario usuario)
      {
         _context.Add(usuario);
         await _context.SaveChangesAsync();
      }

		public async Task<Boolean> ValidateExistence(Usuario usuario)
		{
			var validateExistence = await _context.Usuario.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
         return validateExistence;
		}
	}
}
