namespace _02_MVCHoca.Utilities
{
    public static class FileOperations
    {
        public static string ResimYukle(IFormFile dosya, string path = "wwwroot/Resimler/")
        {

            string guid = Guid.NewGuid().ToString();
            string dosyaAdi = guid + "_" + dosya.FileName;
            string dosyaYolu = path + guid + "_" + dosya.FileName;

            FileStream fs = new FileStream(dosyaYolu, FileMode.Create);
            dosya.CopyTo(fs);
            fs.Close();

            return dosyaAdi; //dosyaAdi;

        }
    }
}
