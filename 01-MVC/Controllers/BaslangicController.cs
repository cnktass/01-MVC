using _01_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC.Controllers
{
    public class BaslangicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "Merhaba MVC Core";
        //}

        public IActionResult VeriAktar()
        {
            ViewData["mesaj"] = "Merhaba";
            ViewBag.Message = "Hello";

            Urun urun = new() { UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 };

            ViewData["urun"] = urun;
            ViewBag.Product = urun;

            List<Urun> urunler = new List<Urun>
            {
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 }
            };

            ViewBag.Urunler = urunler;
            

            return View();
        }

        public IActionResult ModelKullanimi()
        {
            Urun urun = new() { UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 };
            return View(urun);
        }

        public IActionResult TumUrunler()
        {
            List<Urun> urunler = new List<Urun>
            {
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 111, UrunAdi = "T Cetveli", Fiyat = 1500 }
            };
            return View(urunler);
        }

        public IActionResult VeriAl()
        {
            return View();
        }

        public IActionResult VeriYakala_GET()
        {
            string veriler = Request.QueryString.Value;
            return Content(veriler);
        }

        //RequestForm Kullanımı...
        public IActionResult VeriYakala_RF()
        {
            string ad = Request.Form["ad"];
            string soyad = Request.Form["soyad"];
            int yas = int.Parse(Request.Form["yas"]);

            return Content(ad + " " + soyad + " " + yas);
        }
        //IFormCollecttion Kullanimi...
        public IActionResult VeriYakala_IFC(IFormCollection frm)
        {
            string ad = frm["ad"];
            string soyad = frm["soyad"];
            int yas = int.Parse(frm["yas"]);

            return Content(ad + " " + soyad + " " + yas);
        }

        //Parametre Kullanimi...
        public IActionResult VeriYakala_PRMS(string ad, string soyad, int yas)
        {
           

            return Content(ad + " " + soyad + " " + yas);
        }

        //Model Kullanimi...
        public IActionResult VeriYakala_MDL(Personel personel)
        {


            return Content(personel.Ad + " " + personel.Soyad + " " + personel.Yas);
        }
    }
}
