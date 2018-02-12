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
    }
}