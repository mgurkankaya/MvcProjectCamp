using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EFMessageDal());
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
            ViewBag.a1=cm.GetList().Count();
            ViewBag.a2 = mm.GetListInbox().Count();
            ViewBag.a3 = mm.GetListSendBox().Count();
            return PartialView();
        }
    }
}