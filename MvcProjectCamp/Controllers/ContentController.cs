﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var value = cm.GetListById(id);
            return View(value);
        }

        public PartialViewResult GetAllContent(string p)
        {
            var value = cm.GetList(p);
            return PartialView(value);
        }

        public ActionResult ListAllContent(string p="")
        {
            var value = cm.GetList(p);
            return View(value);
        }
    }
}