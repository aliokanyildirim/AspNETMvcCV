using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMvcCV.Models.Entity;

namespace ASPNETMvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimdas.ToList();
            return View(degerler);
        }
        public ActionResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedyas.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlers.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimlerim = db.TblEğitimlerim.ToList();
            return PartialView(egitimlerim);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TblYeteneklers.ToList();
            return PartialView(yeteneklerim);
        }

        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerims.ToList();
            return PartialView(hobilerim);
        }

        public PartialViewResult Sertifikalar() 
        {
            var sertifikalar = db.TblSertifikalarims.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tblİletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tblİletisim.Add(t);   // t den gelen değerleri buraya ekle.
            db.SaveChanges();        // sonra değişikleri kaydet
            return PartialView();
        }
    }
}