﻿namespace _02_MVCHoca.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
