using BackEnd.DataAccess;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CuestionarioController : ControllerBase
	{
		private readonly ICuestionarioService _cuestionarioService;
		public CuestionarioController(ICuestionarioService cuestionarioService)
		{
			this._cuestionarioService = cuestionarioService;
		}

		[HttpPost]
		//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<IActionResult> Post([FromBody] Cuestionario cuestionario)
		{
			try
			{
				var identity = this.HttpContext.User.Identity as ClaimsIdentity;
				Int32 idUsuario = JwtConfigurator.intGetTokenIdUsuario(identity);

				cuestionario.UsuarioId = 1;
				cuestionario.Activo = 1;
				cuestionario.FechaCreacion = DateTime.Now;
				await this._cuestionarioService.CreateCuestionario(cuestionario);

				CuestionarioAccess cuestionarioAccess = new CuestionarioAccess();

				cuestionarioAccess.Process(cuestionario);
				Int32 id = cuestionarioAccess.CuestionarioId;

				foreach (Pregunta pregunta in cuestionario.listPreguntas)
				{
					PreguntaAccess preguntaAcess = new PreguntaAccess();
					preguntaAcess.Process(pregunta, id);
					Int32 preguntaId = preguntaAcess.PreguntaId;

					foreach (Respuesta respuesta in pregunta.listRespuestas)
					{
						RespuestaAccess respuestaAccess = new RespuestaAccess();
						respuestaAccess.Process(respuesta, preguntaId);
					}
				}
				return this.Ok(new { message = "Se agregó el cuestionario exitosamente" });
			}
			catch (Exception ex)
			{
				return this.BadRequest(ex.Message);
			}

		}

		[Route("GetListCuestionarioByUser")]
		[HttpGet]
		public async Task<IActionResult> GetlistCuestionarioByUser()
		{
			try
			{
				var identity = this.HttpContext.User.Identity as ClaimsIdentity;
				Int32 idUsuario = JwtConfigurator.intGetTokenIdUsuario(identity);

				var listCuestionario = await this._cuestionarioService.GetCuestionariosByUser(idUsuario);
				return this.Ok(listCuestionario);
			}
			catch (Exception ex)
			{
				return this.BadRequest(ex.Message);
			}
		}

		[HttpGet("{idCuestionario}")]
		public async Task<IActionResult> Get(Int32 idCuestionario)
		{
			try
			{
				var cuestionario = await this._cuestionarioService.GetCuestionario(idCuestionario);
				return this.Ok(cuestionario);
			}
			catch (Exception ex)
			{
				return this.BadRequest(ex.Message);
			}
		}
	}
}
