namespace _02_MVCHoca.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public ushort Fiyat { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }
        public int KategoriID { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
