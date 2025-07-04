using Microsoft.Data.SqlClient;
using Dapper;

public class bd
{
    public List<integrante> iniciarSesion()
    {
        List<integrante> integrantes = new List<integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrantes WHERE nombre=@intento";
            integrantes = connection.Query<integrante>(query).ToList();

        }        
        return integrantes;
    } 
}