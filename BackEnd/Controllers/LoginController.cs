using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;
		private readonly IConfiguration _config;
		public LoginController(ILoginService loginService, IConfiguration config)
		{
			this._loginService = loginService;
			this._config = config;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Usuario usuario)
		{
			try
			{
				usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
				var user = await this._loginService.ValidateUser(usuario);
				if (user == null)
				{
					return this.BadRequest(new { message = "Usuario o contraseña inválidos" });
				}
				String tokenString = JwtConfigurator.GetToken(user, this._config);
				return this.Ok(new { token = tokenString });

			}
			catch (Exception ex)
			{
				return this.BadRequest(ex.Message);
			}
		}

	}
}
