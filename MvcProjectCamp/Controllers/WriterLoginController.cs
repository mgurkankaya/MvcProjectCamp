using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {


                  var writerUserInfo =  wlm.GetWriter(writer.WriterMail,writer.WriterPassword);


            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["writerMail"] = writerUserInfo.WriterMail;
                Session["writerName"]= writerUserInfo.WriterName + " " + writerUserInfo.WriterSurname;
                Session["writerImg"]= writerUserInfo.WriterImage;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
                return RedirectToAction("Index");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}