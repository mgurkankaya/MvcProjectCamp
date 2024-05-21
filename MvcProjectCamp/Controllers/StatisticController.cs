using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());  
        public ActionResult Index()
        {
            var value = cm.GetList();
            ViewBag.v1 = value.Count();
            var a1 = value.Where(x=>x.CategoryStatus == true).Count();
            var a2 = value.Where(x=>x.CategoryStatus == false).Count();
            ViewBag.v2 = a2- a1;
            ViewBag.v3 = value.Where(x=>x.CategoryName=="Yazılım").Count();

            var value4 = wm.GetList();
            ViewBag.v4 = (from x in value4 select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.v5 = value.Where(u => u.CategoryId == cm.GetList().GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();


            return View();
        }
    }
}