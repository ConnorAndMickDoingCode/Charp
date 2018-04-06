using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Topic4.Models;

namespace Topic4.Controllers
{
    public class CustomerController : Controller
    {
        public static List<CustomerModel> CustomerList;

        public CustomerController()
        {
            CustomerList = new List<CustomerModel>
            {
                new CustomerModel(0, "Jeff Gumory", 27),
                new CustomerModel(1, "Hank Imm", 23),
                new CustomerModel(2, "Mary Ewe", 32),
                new CustomerModel(3, "Sally Odes", 21)
            };
        }


        [HttpGet]
        public ActionResult Index()
        {
            // It's Tuple Time
            Tuple<List<CustomerModel>, CustomerModel> tuple =
                new Tuple<List<CustomerModel>, CustomerModel>(CustomerList, CustomerList[0]);
            return View("Customer", tuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(String customerString)
        {
            return PartialView("_CustomerDetails", CustomerList[Int32.Parse(customerString)]);
        }

        [HttpPost]
        public String GetMoreInfo(String customerString)
        {
            return "User ID: " + customerString + ".";
        }
    }
}