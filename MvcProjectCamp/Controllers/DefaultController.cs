using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm  = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListById(id);
            return PartialView(contentList);
        }
    }
}