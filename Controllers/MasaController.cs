using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CafeOtomasyon.Models.Entity;

namespace CafeOtomasyon.Controllers
{
    public class MasaController : Controller
    {
        // GET: Masa
        cafedbEntities16 db = new cafedbEntities16();
        
        public ActionResult Index()
        {

            return View(db.Masa.ToList());

        }
       
    }
}