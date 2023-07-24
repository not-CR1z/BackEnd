using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
	public interface IUsuarioRepository
	{
		Task SaveUser(Usuario usuario);
		Task<Boolean> ValidateExistence(Usuario usuario);
		Task<Usuario> ValidatePassword(Int32 idUsuario, String passwordAnterior);
		Task UpdatePassword(Usuario usuario);

	}
}
