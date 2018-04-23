using System.Web.Mvc;

namespace CLC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public ActionResult Home()
        {
            return View("Index");
        }
    }
}