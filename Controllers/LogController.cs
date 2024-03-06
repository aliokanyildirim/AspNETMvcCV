using ASPNETMvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPNETMvcCV.Controllers
{
    [AllowAnonymous]
    public class LogController : Controller
    {
        // GET: Log
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.TblAdmins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi &&
            x.Sifre == p.Sifre); // ya null dönecek ya da bir değer dönecek null dönmesi için ıd şifrenin uyumlu olmaması gereklidir.
            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // terketmek anlamında.
           return RedirectToAction("Index", "Log"); // index e yönlendir , Loginin içindeki.
        }
    }
}