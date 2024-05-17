using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context context = new Context();
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator validator = new WriterValidator();
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }

        public ActionResult MyHeaading(string p, int pager=1)
        {

            
            p = (string)Session["WriterMail"];
            var writerIdInfo=context.Writers.Where(x=>x.WriterMail== p).Select(y=>y.WriterId).FirstOrDefault();
            var value = hm.GetListByWriter(writerIdInfo).ToPagedList(pager, 10);
            return View(value);
        }

        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading( Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            hm.HeadingAddBl(heading);
            return RedirectToAction("MyHeaading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                 ).ToList();

            ViewBag.vlc = valueCategory;
            var value = hm.GetbyId(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdateBl(heading);
            return RedirectToAction("MyHeaading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetbyId(id);
            if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
                hm.HeadingDeleteBl(headingvalues);
            }
            else
            {
                headingvalues.HeadingStatus = true;
                hm.HeadingDeleteBl(headingvalues);
            }

            return RedirectToAction("MyHeaading");
        }

        public ActionResult AllHeading(int page=1)
        {

            var headings = hm.GetList().ToPagedList(page,10);
            return View(headings);
        }
    }
}