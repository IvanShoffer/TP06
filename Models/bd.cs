using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
public class bd
{
    private string _connectionString = @"Server=localhost;
    DataBase=TP06;Integrated Security=True;TrustServerCertificate=true;";

    public List<integrante> iniciarSesion(string intentoU, string intentoC)
    {
        List<integrante> listaIntegrantes = new List<integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante WHERE nombreGrupo = (SELECT nombreGrupo FROM Integrante WHERE nombre=@pIntentoU AND contraseña=@pIntentoC)";
            listaIntegrantes = connection.Query<integrante>(query, new{pIntentoU=intentoU, pIntentoC=intentoC}).ToList();
        }        
        return listaIntegrantes;
    } 
    
}