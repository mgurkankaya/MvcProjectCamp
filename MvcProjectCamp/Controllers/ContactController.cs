using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var value = cm.GetList();
            return View(value);
        }

        public ActionResult GetContactDetails(int id)
        {
            var value=cm.GetbyId(id);
            return View(value);
        }

        public PartialViewResult ContactSideBar()
        {
            return PartialView();
        }
    }
}