using _01_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC.Controllers
{
    
    public class UrunController : Controller
    {
        static List<Urun> urunListesi = new List<Urun>();
        public IActionResult UrunSayfasi()
        {
            return View(urunListesi);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            urun.UrunID = urunListesi.Count + 1;
            urunListesi.Add(urun);   

            return RedirectToAction("UrunSayfasi");
        }

        [HttpGet]
        public IActionResult Sil(int id)
        {
            var urun = urunListesi.FirstOrDefault(u => u.UrunID == id);
            
          
        }
    }
}
