using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Persistence.Content;
using BackEnd.Persistence.Repositories;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


namespace BackEnd
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.


			//conexión con oracle
			builder.Services.AddDbContext<AplicationDbContext>(options =>
			options.UseOracle(builder.Configuration.GetConnectionString("Conexion")));

			builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddScoped<IUsuarioService, UsuarioService>();



			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAuthorization();
			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}


}
