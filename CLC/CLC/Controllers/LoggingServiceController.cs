using CLC.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class LoggingServiceController : Controller
    {
        private readonly ILogger logger;

        public LoggingServiceController(ILogger service)
        {
            this.logger = service;
        }
        
        public string Index()
        {
            logger.Info("Test Logging Service index() was super duper invoked!");
            return "Test Logging Service index() was super duper invoked!";
        }
        // GET: LoggingService
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}