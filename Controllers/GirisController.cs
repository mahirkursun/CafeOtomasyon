using CafeOtomasyon.Models.Giris;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOtomasyon.Controllers
{
    public class GirisController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = @"Server=MAHIR\SQLEXPRESS; Database= cafedb; integrated security=SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(GirisDurum acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Giris where kulAd='" + acc.kulAd + "' and sifre='" + acc.sifre + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                con.Close();
                return RedirectToAction("Index");
            }


        }
    }
}