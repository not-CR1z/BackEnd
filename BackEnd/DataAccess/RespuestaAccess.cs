using BackEnd.Domain.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BackEnd.DataAccess
{
	public class RespuestaAccess
	{
		public void Process(Respuesta respuesta, Int32 preguntaId)
		{
			using (OracleConnection connection = new OracleConnection(DBConstants.ConnectionString))
			{
				connection.Open();
				using (OracleCommand command = new OracleCommand("INSERT INTO Respuesta (Descripcion, EsCorrecta, PreguntaId) VALUES" +
					"(:Descripcion, :EsCorrecta, :PreguntaId) RETURNING id INTO :id_param", connection))
				{
					// Bool esCorrecta a int32
					Int32 esCorrecta = Convert.ToInt32(respuesta.EsCorrecta);
					command.Parameters.Add("Descripcion", respuesta.Descripcion);
					command.Parameters.Add("EsCorrecta", esCorrecta);
					command.Parameters.Add("PreguntaId", preguntaId);

					// Set PrimaryKey
					command.Parameters.Add(new OracleParameter
					{
						ParameterName = ":id_param",
						OracleDbType = OracleDbType.Int64,
						Direction = ParameterDirection.Output
					});

					String id = Convert.ToString(command.Parameters[":id_param"].Value);
					command.ExecuteNonQuery();
				}
			}
		}
	}
}

