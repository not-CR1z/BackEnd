using BackEnd.Domain.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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
					"(:Nombre, :Descripcion, :FechaCreacion, :Activo, :UsuarioId) RETURNING id INTO :id_param", connection))
				{
					command.Parameters.Add("Nombre", cuestionario.Nombre);
					command.Parameters.Add("Descripcion", cuestionario.Descripcion);
					command.Parameters.Add("FechaCreacion", cuestionario.FechaCreacion);
					command.Parameters.Add("Activo", cuestionario.Activo);
					command.Parameters.Add("UsuarioId", cuestionario.UsuarioId);

					// Set PrimaryKey 
					command.Parameters.Add(new OracleParameter
					{
						ParameterName = ":id_param",
						OracleDbType = OracleDbType.Int64,
						Direction = ParameterDirection.Output
					});
					command.ExecuteNonQuery();

					String cuestionarioId = Convert.ToString(command.Parameters[":id_param"].Value);
					this.CuestionarioId = Int32.Parse(cuestionarioId);
				}
			}
		}
		public Int32 CuestionarioId { get; set; }
	}
}

