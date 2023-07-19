﻿using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.DTO;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		public async Task<IActionResult> Post([FromBody] Usuario usuario)
		{
			try
			{

				var validateExistence = await _usuarioService.ValidateExistence(usuario);
				if (validateExistence)
				{
					return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe" });
				}
				usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
				await _usuarioService.SaveUser(usuario);

				return Ok(new { message = "Usuario registrado con éxito!" });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//localhost:xxx/api/Usuario/CambiarPassword
		[Route("CambiarPassword")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPut]
		public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
		{
			try
			{
				var identity = HttpContext.User.Identity as ClaimsIdentity;

				int idUsuario = JwtConfigurator.intGetTokenIdUsuario(identity);
				string passwordEnciptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
				var usuario = await _usuarioService.ValidatePassword(idUsuario, passwordEnciptado);
				if (usuario == null)
				{
					return BadRequest(new { message = "La contraseña es incorrecta" });
				}
				else
				{
					usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.nuevaPassword);
					await _usuarioService.UpdatePassword(usuario);
					return Ok(new { message = "La password fue actualizada con éxtito!" });
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
