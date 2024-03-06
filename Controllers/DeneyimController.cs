using ASPNETMvcCV.Models.Entity;
using ASPNETMvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degeler = repo.List();
            return View(degeler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
            // ekleme işlemini yap sonrasında beni index'e yönlendir.
        }

        public ActionResult DeneyimSil(int id)
        {
           TblDeneyimler t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimler t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimler p)
        {
            TblDeneyimler t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik= p.AltBaslik;
            t.Tarih= p.Tarih;
            t.Aciklama= p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}