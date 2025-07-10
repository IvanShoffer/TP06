using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
public class bd
{
    private string _connectionString = @"Server=localhost;
    DataBase=TP06;Integrated Security=True;TrustServerCertificate=true;";

    public List<integrante> iniciarSesion(string intentoU, string intentoC)
    {
        List<integrante> integrantes = new List<integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrantes WHERE nombreGrupo = (SELECT nombreGrupo FROM Integrantes WHERE nombre=@pIntentoU AND contraseña=@pIntentoC)";
            integrantes = connection.Query<integrante>(query, new{pIntentoU=intentoU}, new {pIntentoC=intentoC}).ToList();
        }        
        return integrantes;
    } 
    
}