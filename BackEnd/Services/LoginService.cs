﻿using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
	public class LoginService : ILoginService
	{
		private readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			this._loginRepository = loginRepository;
		}

		public async Task<Usuario> ValidateUser(Usuario usuario)
		{
			return await this._loginRepository.ValidateUser(usuario);
		}
	}
}
