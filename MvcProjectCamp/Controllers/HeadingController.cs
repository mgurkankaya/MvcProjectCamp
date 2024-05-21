using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
       
        public ActionResult Index()
        {
            var value = hm.GetList();
            return View(value);
        }
        public ActionResult HeadingReport()
        {
            var value = hm.GetList();
            return View(value);
        }



        [HttpGet]
        public ActionResult AddHeading()
        { 

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString()
                                                  }
                                                  ).ToList();

            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurname,
                                                      Value = x.WriterId.ToString()
                                                  }
                                                 ).ToList();

            ViewBag.vlw = valueWriter;
            return View();

        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult validationResult = headingValidator.Validate(heading);
            if (validationResult.IsValid)
            {

                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAddBl(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



            
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
            return RedirectToAction("Index");
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
            
            return RedirectToAction("Index");
        }

        }
}