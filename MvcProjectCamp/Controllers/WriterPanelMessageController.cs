using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var value = mm.GetListInbox(p);
            return View(value);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var value = mm.GetListSendBox(p);
            return View(value);
        }

     

        public ActionResult GetInboxDetails(int id)
        {
            var value = mm.GetbyId(id);
            return View(value);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var value = mm.GetbyId(id);
            return View(value);
        }

        public ActionResult NewMessage()
        {


            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            ValidationResult result = mv.Validate(message);
            if (result.IsValid)
            {
                string sender = (string)Session["WriterMail"];
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBl(message);
                return RedirectToAction("Sendbox");
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


        public PartialViewResult MessageSideBar()
        {
            return PartialView();
        }


    }
}