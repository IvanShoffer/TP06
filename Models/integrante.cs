using Newtonsoft.Json;

public class integrante{
    [JsonProperty]
    private int id;
    [JsonProperty]
    private string nombre;
    [JsonProperty]
    private string contraseña;
    [JsonProperty]
    private string hobbie;
    [JsonProperty]
    private bool restriccionAlimenticia;
    [JsonProperty]
    private string domicilio;
    [JsonProperty]
    private int edad;
    [JsonProperty]
    private string nombreGrupo;

    public integrante(){

    }
}