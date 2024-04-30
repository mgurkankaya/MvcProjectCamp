using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
          
            if (validationResult.IsValid)
            {
                cm.CategoryAddBl(category);
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

        public ActionResult DeleteCategory(int id)
        {
            var value = cm.GetbyId(id);
            cm.CategoryDeleteBl(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var value = cm.GetbyId(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdateBl(category);
            return RedirectToAction("Index");
        }
    }
}