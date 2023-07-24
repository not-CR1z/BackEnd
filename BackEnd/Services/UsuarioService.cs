using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			this._usuarioRepository = usuarioRepository;
		}

		public async Task SaveUser(Usuario usuario)
		{
			await this._usuarioRepository.SaveUser(usuario);

		}

		public async Task<Boolean> ValidateExistence(Usuario usuario)
		{
			return await this._usuarioRepository.ValidateExistence(usuario);
		}

		public async Task<Usuario> ValidatePassword(Int32 idUsuario, String passwordAnterior)
		{
			return await this._usuarioRepository.ValidatePassword(idUsuario, passwordAnterior);
		}

		public async Task UpdatePassword(Usuario usuario)
		{
			await this._usuarioRepository.UpdatePassword(usuario);
		}

	}
}
