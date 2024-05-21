using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adm.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adm.GetById(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adm.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = adm.GetById(id);
            adm.Delete(result);
            return RedirectToAction("Index");
        }
    }
}