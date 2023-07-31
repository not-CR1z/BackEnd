using BackEnd.Domain.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BackEnd.DataAccess
{
	public class PreguntaAccess
	{
		public void Process(Pregunta pregunta, Int32 cuestionarioId)
		{
			using (OracleConnection connection = new OracleConnection(DBConstants.ConnectionString))
			{
				connection.Open();
				using (OracleCommand command = new OracleCommand("INSERT INTO Pregunta (Descripcion, CuestionarioId) VALUES" +
					"(:Descripcion, :CuestionarioId) RETURNING id INTO :id_param", connection))
				{
					command.Parameters.Add("Descripcion", pregunta.Descripcion);
					command.Parameters.Add("CuestionarioId", cuestionarioId);

					// Set PrimaryKey
					command.Parameters.Add(new OracleParameter
					{
						ParameterName = ":id_param",
						OracleDbType = OracleDbType.Int64,
						Direction = ParameterDirection.Output
					});
					command.ExecuteNonQuery();

					String preguntaId = Convert.ToString(command.Parameters[":id_param"].Value);
					this.PreguntaId = Int32.Parse(preguntaId);
				}
			}
		}
		public Int32 PreguntaId;
	}
}