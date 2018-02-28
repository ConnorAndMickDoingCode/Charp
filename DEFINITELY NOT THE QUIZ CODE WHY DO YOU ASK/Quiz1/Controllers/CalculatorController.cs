using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz1.Models;
using Quiz1.Services;

namespace Quiz1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            var model = new CalculatorModel
            {
                Left = 0,
                Result = 0,
                Right = 0,
                Action = "+"
            };
            return View("Calculator", model);
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
            var calculator = new CalculatorService(model);
            return PartialView("_CalculatorOutput", calculator.Calculate());
        }
    }
}