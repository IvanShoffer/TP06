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
    
    public void AgregarIntegrante(integrante jugador)
{
    string query = @"INSERT INTO integrante 
    (nombre, contraseña, hobbie, restriccionAlimenticia, domicilio, edad, nombreGrupo)VALUES (@pNombre, @pContraseña, @pHobbie, @pRestriccion, @pDomicilio, @pEdad, @pGrupo)";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new
        {
            pNombre = jugador.nombre,
            pContraseña = SeguridadHelper.HashearSHA256(jugador.contraseña),
            pHobbie = jugador.hobbie,
            pRestriccion = jugador.restriccionAlimenticia,
            pDomicilio = jugador.domicilio,
            pEdad = jugador.edad,
            pGrupo = jugador.nombreGrupo
        });
    }
}
    
}