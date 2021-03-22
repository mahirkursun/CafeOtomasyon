using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeOtomasyon.Models.Entity;

namespace CafeOtomasyon.Controllers
{
    public class Masa7Controller : Controller
    {
        // GET: Masa7
        cafedbEntities16 db = new cafedbEntities16();
        public ActionResult Index()
        {
            /*Ürün Listesi*/


            List<SelectListItem> siparisUrun = (from Siparis in db.Urun.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = Siparis.urunAdi,
                                                    Value = Siparis.urunID.ToString()
                                                }).ToList();
            ViewData["Urun"] = siparisUrun;

            /*Masa Listesi*/

            List<SelectListItem> siparisMasa = (from Siparis in db.Masa.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = Siparis.masaID.ToString(),
                                                    Value = Siparis.masaID.ToString()
                                                }).ToList();
            ViewBag.siparisMasa = siparisMasa;



            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            ViewBag.Urun = new SelectList(db.Urun, "urunID", "urunAdi");

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Siparis p)
        {

            db.Siparis.Add(p);
            db.SaveChanges();
            return Redirect("~/SiparisDetay/Index");
        }
    }
}