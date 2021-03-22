using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeOtomasyon.Models.Entity;

namespace CafeOtomasyon.Controllers
{
    public class SiparisDetayController : Controller
    {
        // GET: SiparisDetay
        cafedbEntities16 db = new cafedbEntities16();

        public ActionResult Index()
        {
            var degerler = db.Siparis.ToList();
            return View(degerler);
        }
        public ActionResult Sil(int id)
        {

            var siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SiparisGetir(int id)
        {
            var urun = db.Siparis.Find(id);
            return View("SiparisGetir", urun);
        }
        public ActionResult Guncelle(Siparis p)
        {
            var urun = db.Siparis.Find(p.siparisID);
            urun.siparisUrun = p.siparisUrun;
            urun.siparisAdet = p.siparisAdet;
            urun.siparisZaman = p.siparisZaman;
            urun.siparisMasa = p.siparisMasa;
            urun.siparisDurum = p.siparisDurum;
            urun.siparisFiyat = p.siparisFiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}