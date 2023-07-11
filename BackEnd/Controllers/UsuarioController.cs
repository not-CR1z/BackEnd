using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;
		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] Usuario usuario)
		{
			try
			{

				var validateExistence = await _usuarioService.ValidateExistence(usuario);
				if (validateExistence)
				{
					return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe" });
				}
				await _usuarioService.SaveUser(usuario);

				return Ok(new { message = "Usuario registrado con éxito!" });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
