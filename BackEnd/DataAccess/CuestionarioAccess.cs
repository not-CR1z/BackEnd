using BackEnd.Domain.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Diagnostics;

namespace BackEnd.DataAccess
{
	public class CuestionarioAccess
	{
		public void Process(Cuestionario cuestionario)
		{

			using (OracleConnection connection = new OracleConnection(DBConstants.ConnectionString))
			{
				connection.Open();
				using (OracleCommand command = new OracleCommand("INSERT INTO Cuestionario (Nombre, Descripcion, FechaCreacion, Activo, UsuarioId) VALUES" +
					"(:Nombre, :Descripcion, :FechaCreacion, :Activo, :UsuarioId) ", connection))
				{
					//command.Parameters.Add("Id", 1);
					command.Parameters.Add("Nombre", cuestionario.Nombre);
					command.Parameters.Add("Descripcion", cuestionario.Descripcion);
					command.Parameters.Add("FechaCreacion", cuestionario.FechaCreacion);
					command.Parameters.Add("Activo", cuestionario.Activo);
					command.Parameters.Add("UsuarioId", cuestionario.UsuarioId);

					command.ExecuteNonQuery();
				}
			}
		}
		public void Process(Pregunta pregunta)
		{

			using (OracleConnection connection = new OracleConnection(DBConstants.ConnectionString))
			{
				connection.Open();
				using (OracleCommand command = new OracleCommand("INSERT INTO Pregunta (Id, Descripcion, CuestionarioId) VALUES" +
					"(:Id, :Descripcion, :CuestionarioId) ", connection))
				{
					//command.Parameters.Add("Id", 1);
					command.Parameters.Add("Descripcion", pregunta.Descripcion);
					command.Parameters.Add("CuestionarioId", pregunta.CuestionarioId);

					command.ExecuteNonQuery();
				}
			}
		}
		public void Process(Respuesta respuesta)
		{

			using (OracleConnection connection = new OracleConnection(DBConstants.ConnectionString))
			{
				connection.Open();
				using (OracleCommand command = new OracleCommand("INSERT INTO Respuesta (Id, Descripcion, EsCorrecta, PreguntaId) VALUES" +
					"(:Id, :Descripcion, :EsCorrecta, :Pregunta) ", connection))
					{
						//command.Parameters.Add("Id", 1);
						command.Parameters.Add("Descripcion", respuesta.Descripcion);
						command.Parameters.Add("EsCorrecta", respuesta.EsCorrecta);
						command.Parameters.Add("PreguntaId", respuesta.PreguntaId);

						command.ExecuteNonQuery();
					}
				}
			}
		}
	}

