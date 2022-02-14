using LoginGoogle.Helper;
using System.Web.Mvc;

namespace LoginGoogle.Controllers
{
    public class HomeController : Controller
    {        
        public string email = "";
        
        
        [Permisos(PermisosModulo.Ventas.VerClientes, Roles = "Admin,Cliente")]
        public ActionResult Index()
        {   
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var e = HttpContext.Session;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}