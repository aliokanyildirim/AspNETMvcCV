using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMvcCV.Models.Entity;
using ASPNETMvcCV.Repositories;
namespace ASPNETMvcCV.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tblİletisim> repo = new GenericRepository<Tblİletisim>();  
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult MessageSil(int id)
        {
            var message = repo.Find(x => x.ID == id);
            repo.TDelete(message);
            return RedirectToAction("Index");
        }
    }
}