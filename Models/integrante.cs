public class integrante{
    public string nombre{get; private set;}
    public string contraseña{get; private set;}
    public string hobbie{get; private set;}
    public bool restriccionAlimenticia{get; private set;}
    public string domicilio{get; private set;}
    public int edad{get; private set;}
    public string nombreGrupo{get; private set;}

   public integrante(string nombre, string contraseña, string hobbie, bool restriccionAlimenticia, string domicilio, int edad, string nombreGrupo)
    {
        this.nombre = nombre;
        this.contraseña = contraseña;
        this.hobbie = hobbie;
        this.restriccionAlimenticia = restriccionAlimenticia;
        this.domicilio = domicilio;
        this.edad = edad;
        this.nombreGrupo = nombreGrupo;
    }
}