using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        bd baseDatos = new bd();
        HttpContext.Session.SetString("baseDatos", objeto.ObjectToString(baseDatos));
        return View("Index");
    }

    public IActionResult iniciarSesion(string intentoU, string intentoC){
        bd baseDatos = objeto.StringToObject<bd>(HttpContext.Session.GetString("baseDatos"));
        @ViewBag.listaIntegrantes=baseDatos.iniciarSesion(intentoU,intentoC);
        HttpContext.Session.SetString("baseDatos", objeto.ObjectToString(baseDatos));
        return View("mostrarEquipo");
    }
   public IActionResult InsertarJugador(string nombre, string contraseña, string hobbie, bool restriccionAlimenticia, string domicilio, int edad, string nombreGrupo)
{
    bd baseDatos = objeto.StringToObject<bd>(HttpContext.Session.GetString("baseDatos"));
    integrante jugador = new integrante(nombre, contraseña, hobbie, restriccionAlimenticia, domicilio, edad, nombreGrupo);

     
    baseDatos.AgregarIntegrante(jugador);
    HttpContext.Session.SetString("baseDatos", objeto.ObjectToString(baseDatos));
    return View("agregarJugador");
 
}
}
