﻿using _02_MVCHoca.Data;
using _02_MVCHoca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _02_MVCHoca.Controllers
{
    public class UrunController : Controller
    {

        //Eski Usul...
        //Sakın yapmayınız -> Cunku DI kullanmalıyız
        //UrunDbContext db = new UrunDbContext(); // Bu yöntem önerilmiyor

        private readonly UrunDbContext _dbContex;

        public UrunController(UrunDbContext dbContex)
        {
            _dbContex = dbContex;
        }

        public IActionResult Index()
        {
            //Varasyılan olarak navigation propertyler joinlemeden gelir, include yaparsak joinlenerek gelir.
            var urunler = _dbContex.Urunler.Include(x => x.Kategori).ToList(); //->Eager Loading
            //var urunler = _dbContex.Urunler.ToList();
            return View(urunler);
        }

        public IActionResult TumKategoriler()
        {
            //Tum kategorileri ekranda sırasız liste olarak goster
            //var kategoriler = db.Kategoriler.ToList(); 

            return View(_dbContex.Kategoriler);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            ViewBag.Kategoriler = new SelectList(_dbContex.Kategoriler, "KategoriID", "KategoriAdi");
            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(Urun urun, IFormFile urunResmi)
        {
            //Guid ile yapmazsak aynı dosyadan tekrar yükelnirse üstüne yazacagı için yanlıs bir kullanım yapmıs oluruz
            //Resim(dosya) ile ilgili yapılacaklar...
            //1 - Dosyayı sunucuya yükle
            //2 - Dosya adını urun modeline yaz(GUID)

            string guid = Guid.NewGuid().ToString();
            string dosyaAdi = "wwwroot/Resimler/" + guid + "_" + urunResmi.FileName;
            FileStream fs = new FileStream(dosyaAdi, FileMode.Create);
            urunResmi.CopyTo(fs);
            fs.Close();

            urun.Resim = guid + "_" + urunResmi.FileName; //dosyaAdi;

            _dbContex.Urunler.Add(urun);
            _dbContex.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UrunDetay(int id)
        {
            var urun = _dbContex.Urunler.Include(u => u.Kategori).FirstOrDefault(u => u.UrunID == id);
            return View(urun);
        }

    }
}
