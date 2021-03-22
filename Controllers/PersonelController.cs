using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeOtomasyon.Models.Entity;

namespace CafeOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        cafedbEntities16 db = new cafedbEntities16();
        public ActionResult Index()
        {
            var degerler = db.Personel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(Personel p1)
        {
            db.Personel.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var per = db.Personel.Find(id);
            return View("Guncelle", per);

        }
        public ActionResult Güncelle(Personel p1)
        {
            var gncll = db.Personel.Find(p1.personelID);
            gncll.personelAd = p1.personelAd;
            gncll.personelSoyad = p1.personelSoyad;
            gncll.personelTelefon = p1.personelTelefon;
            gncll.personelBolum = p1.personelBolum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}