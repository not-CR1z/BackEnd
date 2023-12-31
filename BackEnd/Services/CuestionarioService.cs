﻿using BackEnd.DataAccess;
using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
	public class CuestionarioService : ICuestionarioService
	{
		private readonly ICuestionarioRepository _cuestionarioRepository;

		public CuestionarioService(ICuestionarioRepository cuestionarioRepository)
		{
			this._cuestionarioRepository = cuestionarioRepository;
		}
		public async Task CreateCuestionario(Cuestionario cuestionario)
		{
			//await _cuestionarioRepository.CreateCuestionario(cuestionario);

			CuestionarioAccess cuestionarioAccess = new CuestionarioAccess();
			cuestionarioAccess.Process(cuestionario);
		}

		public async Task<List<Cuestionario>> GetListCuestionarioByUser(Int32 idUsuario)
		{
			return await _cuestionarioRepository.GetListCuestionarioByUser(idUsuario);
		}

		public async Task<Cuestionario> GetCuestionario(Int32 idCuestionario)
		{
			return await _cuestionarioRepository.GetCuestionario(idCuestionario);
		}
	}
}
