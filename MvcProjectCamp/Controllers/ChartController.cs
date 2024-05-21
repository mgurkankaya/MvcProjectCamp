using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass> ();
            ct.Add(new CategoryClass()
            { 
                CategoryName = "Php",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Kotlin",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Frontend",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Asp.Net",
                CategoryCount = 1
            });
            
            return ct;
        }
    }
}