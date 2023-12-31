using BackEnd.DataAccess;
using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Persistence.Content;
using BackEnd.Persistence.Repositories;
using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackEnd
{
	public class Program
	{
		public static void Main(String[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.


			//conexi�n con oracle
			builder.Services.AddDbContext<AplicationDbContext>(options =>
			options.UseOracle(builder.Configuration.GetConnectionString("Conexion")));

			DBConstants.ConnectionString = builder.Configuration.GetConnectionString("Conexion");


			// Service
			builder.Services.AddScoped<IUsuarioService, UsuarioService>();
			builder.Services.AddScoped<ILoginService, LoginService>();
			builder.Services.AddScoped<ICuestionarioService, CuestionarioService>();

			// Repository
			builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddScoped<ILoginRepository, LoginRepository>();
			builder.Services.AddScoped<ICuestionarioRepository, CuestionarioRepository>();

			// Cors
			builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

			// Add Authentication
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
								 .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
								 {
									 ValidateIssuer = true,
									 ValidateAudience = true,
									 ValidateLifetime = true,
									 ValidateIssuerSigningKey = true,
									 ValidIssuer = builder.Configuration["Jwt:Issuer"],
									 ValidAudience = builder.Configuration["Jwt:Audience"],
									 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
									 ClockSkew = TimeSpan.Zero
								 });

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAuthorization();
			builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors("AllowWebApp");
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}


}
