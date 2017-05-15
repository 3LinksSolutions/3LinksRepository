using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3LinksSoul.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

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

        public ActionResult CustomerListing(string searchText)
       {
           return View(db.GetCustomer(searchText).ToList());
        }

        public JsonResult AutoCustomerList(string term)
        {
            List<string>Cust;
            Cust = db.Customers.Where(x => x.ContactName.StartsWith(term)).Select(e => e.ContactName).Distinct().ToList();
            return Json(Cust, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult ExportExcel(string searchText)
        public ActionResult ExportExcel()
        {
            var grid = new GridView();
            grid.DataSource = db.Customers.ToList();
            //grid.DataSource = db.GetCustomer(searchText).ToList();
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Customer.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View("");
        }
	}
}