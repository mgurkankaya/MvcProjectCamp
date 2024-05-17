using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo=c.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
            var value = cm.GetListByWriter(writerIdInfo);
            return View(value);
        }

        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            cm.ContentAddBl(content);
            return RedirectToAction("MyContent");
        }

    }
}