using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{

    string[] acertijos = 
        {
        "Te despertas en un sillón en un cuarto desconocido, lentamente recordas como llegaste. En resumen: te secuestró tu ídolo de la infancia, Papá Noel. Intentas abrir la puerta, sin éxito. Lo volves a intentar. Uh, no era porque empujaste en vez de tirar, quizás esté más relacionado con que pide un código númerico. Pensas en resignarte a tu nueva vida como elfo ayudante y comer las galletitas en la mesa ratona como consuelo. Es mayo, por lo que decidis que tenés que irte en seguida para evitar el espíritu navideño permanente ¿Qué contraseña ponés en la puerta?", 
        "Entras en un cuarto aún más grande, está lleno de cajas envueltas, que entran desorganizadamente por una cinta transportadora en un agujero en la pared. Al lado hay una puerta con un cartel ¿Cómo se supone que vas a abrirla esta vez? Hay un enorme mueble con montones de cajoncitos enumerados. En uno de estos seguro está la llave de la puerta, pero revisar todos te va a tomar una eternidad ¿Cuál miras?\nDecidis mirar el cartel en la puerta (210 + 532 + 7 - 59 + 7910 - 1 - 82) x 0 = ¿? ", 
        "Te recuperas rápidamente de la caída para mantener tu dignidad. Aunque no parece importarle a los ocupados elfos a tu alrededor, ignoran tu presencia por el bien del trabajo. Parece estresante. Vas a la puerta admirando los juguetes en proceso de armado. No podes abrirla, casi seguro porque pide un código numérico. Esperas una epifanía mientras lees la lista de juguetes para armar:", 
        "Estás en un establo lleno de renos. Te emocionas, al fin vas a poder salir. Antes de esa emergencia te encargas de una más urgente: detenerte a acariciar a los animales. Lees sus nombres: Rodolfo, Cupido, Trueno y Cometa. Finalmente te acercas a la puerta que necesita un código númerico (¿Cómo hace alguien para acordase de todos estos? Quizás por eso hay pistas tan convenientes) ¿Qué código ponés?"
        };
    string[] salaViews = {"sala1", "sala2", "sala3", "sala4"};
    string[] transicionTexto = {"Tenías razón la primera vez que intentaste mover la puerta, se abre para afuera.", "No hay cajón cero, te apoyas en la puerta para descansar y pensar mejor. Estaba abierta, te caes.", "Abris la puerta y pasas al cuarto cuarto."};
    string[] transicionGif = {"gif1", "gif2", "gif3"};

    public IActionResult Index()
    {
        
        return View("Index");
    }

    public IActionResult Tutorial()
    {
        return View("Tutorial");
    }

    public IActionResult Creditos()
    {
        return View("Creditos");
    }

    public IActionResult Comenzar()
    {
        int sala = Escape.GetEstadoJuego();
        ViewBag.acertijo = acertijos[sala];
        return View(salaViews[sala]);
    }

    public IActionResult Transicion()
    {
        int sala = Escape.GetEstadoJuego();
        ViewBag.texto = transicionTexto[sala-1];
        ViewBag.gif = transicionGif[sala-1];
        return View("transicion");
    }

    public IActionResult Habitacion(int sala, string clave)
    {       
        int salaCorrecta = Escape.GetEstadoJuego();
        if (sala != salaCorrecta)
        {
            return View(salaViews[salaCorrecta]);
        }
        else 
        {            
            Escape.ResolverSala(sala, clave);
        }

        salaCorrecta = Escape.GetEstadoJuego();

        if (sala != salaCorrecta)
        {
            ViewBag.texto = transicionTexto[sala-1];
            ViewBag.gif = transicionGif[sala-1];
            return View("transicion");
        }
        else
        {
            ViewBag.Error = "Volve a intentar. O no. Sos bienvenido en la casa de Papá Noel el tiempo que quieras.";
            ViewBag.acertijo = acertijos[sala];
            return View(salaViews[salaCorrecta]);
        }
    }

}
