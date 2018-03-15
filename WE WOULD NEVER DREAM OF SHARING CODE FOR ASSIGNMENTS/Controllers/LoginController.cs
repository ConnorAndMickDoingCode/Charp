using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Topic4.Models;
using Topic4.Services.Business;
using Topic4.Services.Utility;

namespace Topic4.Controllers
{
    public class LoginController : Controller
    {
        private static readonly CaptainsLogger Log = CaptainsLogger.getInstace();


        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            Log.Info("GET INDEXED (in LoginController.Index)");
            return View("../Default/Welcome");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            try
            {
                Log.Info("Entering LoginController.Login");
                if (!ModelState.IsValid)
                {
                    Log.Info("Model state is NOT valid");
                    return View("../Default/Welcome");
                }
                Log.Info("Model state IS valid");
                var json = new JavaScriptSerializer().Serialize(model);
                Log.Info("Parameters are: " + json);
                SecurityService service = new SecurityService();

                if (service.Authenticate(model))
                    return View("Secure", model);

                Log.Warning("Login did not authenticate user");
                return View("../Default/Welcome", model);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "Exception in LoginController.Login");
                throw;
            }
        }
    }
}