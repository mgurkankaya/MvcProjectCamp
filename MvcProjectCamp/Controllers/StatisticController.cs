using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var value = cm.GetList();
            ViewBag.v1 = value.Count();
            var a1 = value.Where(x=>x.CategoryStatus == true).Count();
            var a2 = value.Where(x=>x.CategoryStatus == false).Count();
            ViewBag.v2 = a2- a1;
            ViewBag.v3 = value.Where(x=>x.CategoryName=="Yazılım").Count();
            return View();
        }
    }
}