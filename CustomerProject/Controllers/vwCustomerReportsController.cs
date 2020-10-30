using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerProject.Models;

namespace CustomerProject.Controllers
{
    public class vwCustomerReportsController : Controller
    {
        private CustomerDataEntities db = new CustomerDataEntities();

        // GET: vwCustomerReports
        public ActionResult Index()
        {
            return View(db.vwCustomerReport.ToList());
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
