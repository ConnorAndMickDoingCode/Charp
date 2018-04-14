using ICA_10.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA_10.Controllers
{
    public class TestLoggingServiceController : Controller
    {

        private readonly ILogger logger;

        public TestLoggingServiceController(ILogger service)
        {
            this.logger = service;
        }

        public string Index()
        {
            logger.Info("Test Logging Service index() invoked!");
            return "Test Logging Service index() invoked.";
        }

        // GET: TestLoggingService
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}