using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeOtomasyon.Models.Entity;

namespace CafeOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        cafedbEntities16 db = new cafedbEntities16();

        public ActionResult Index()
        {
            var degerler = db.Urun.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            ViewBag.urunKategori = new SelectList(db.Kategori, "kategoriID".ToString(), "kategoriAd");
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniUrun(Urun model,HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Icerik/Images/" + File.FileName);
            File.SaveAs(Server.MapPath(path));

            model.urunResim = File.FileName.ToString();
            db.Urun.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urun.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Urun p)
        {
            var urun = db.Urun.Find(p.urunID);
            urun.urunAdi = p.urunAdi;
            urun.urunAyrinti = p.urunAyrinti;
            urun.urunKategori = p.urunKategori;
            urun.urunUcret = p.urunUcret;
            urun.urunStok = p.urunStok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}