using System.Data;
using Microsoft.Data.SqlClient;

public class ConnManager
{
    private string connectionStringConfig;

    public ConnManager(ConnectionStringConfig _connectionStringConfig)
    {
        this.connectionStringConfig = _connectionStringConfig.ConnectionString;
    }

    public DataSet GetDataSetFromAdapter(string queryString, List<SqlParameter> sqlParameters)
    {
        using (SqlConnection conn = new SqlConnection(connectionStringConfig))
        {
            using (var adapter = new SqlDataAdapter(queryString, conn))
            {
                DataSet ds = new DataSet();
                var command = adapter.SelectCommand;
                command.CommandTimeout = 60;

                if (sqlParameters != null)
                    command.Parameters.AddRange(sqlParameters.ToArray());

                try
                {
                    conn.Open();
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                return ds.Tables.Count > 0 ? ds : null;
            }
        }
    }
}