using ICA_10.Models;
using ICA_10.Services.Business;
using ICA_10.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ICA_10.Controllers
{
    [CustomAction]
    public class LoginController : Controller
    {
        private static Logger Log = LogManager.GetLogger("myAppLoggerRules");
       //private static CaptainsLogger Log = CaptainsLogger.getInstace();

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

                Log.Warn("Login did not authenticate user");
                return View("../Default/Welcome", model);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "Exception in LoginController.Login");
                throw;
            }
        }

        [HttpGet]
        [CustomAuthorization]
        public string Protected()
        {
            return "I am a protected method. SUCKS";
        }
    }
}