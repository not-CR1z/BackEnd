﻿using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
	public interface IUsuarioService
	{
		Task SaveUser(Usuario usuario);
		Task<bool> ValidateExistence(Usuario usuario);

	}
}
