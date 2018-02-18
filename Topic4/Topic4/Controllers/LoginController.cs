using System.Web.Mvc;
using Topic4.Models;
using Topic4.Services.Business;

namespace Topic4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("../Default/Welcome");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("../Default/Welcome");

            SecurityService service = new SecurityService();

            // TODO make Views
            if (service.Authenticate(model))
                return View("Secure", model);

            return View("../Default/Welcome", model);
        }
    }
}