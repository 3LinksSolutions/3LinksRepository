using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3LinksSoul.Models;

namespace _3LinksSoul.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        northwindEntities db = new northwindEntities();

        public ActionResult CustomerList()
        {
            return View(db.Customers.ToList());
        }

       public ActionResult CustomerListing()
       {
           return View(db.Customers.ToList());
       }

        //[HttpPost]
        public JsonResult AutoCustomerList(string term)
        {
            //var categ = (from n in db.Customers.ToList() where n.ContactName.StartsWith(Prefix) select new { n.ContactName });
            List<string>Cust;

            Cust = db.Customers.Where(x => x.ContactName.StartsWith(term)).Select(e => e.ContactName).Distinct().ToList();

            //return Json(categ.ToList(), JsonRequestBehavior.AllowGet);
            return Json(Cust, JsonRequestBehavior.AllowGet);
        }
	}
}