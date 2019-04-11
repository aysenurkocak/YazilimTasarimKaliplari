public class TarihFormati

{
    //Singleton deseniyle olusturdugumuz sinif, olusturulan yerde sadece bir adet olabilir. Ayni türden ikinici degiskene izin vermez.
    //tanımlar
    private static TarihFormati db;
    
    private string BaslangicValue
    {
        get
        {
            return Baslangic.ToString("yyyy-MM-dd 00:00:00");
        }
        set
        {
            IFormatProvider pv = new System.Globalization.CultureInfo("tr-TR", true);
            Baslangic = DateTime.Parse(value, pv);
        }
    }
    private string BitisValue
    {
        get
        {
            return Bitis.ToString("yyyy-MM-dd 00:00:00");
        }
        set
        {
            IFormatProvider pv = new System.Globalization.CultureInfo("tr-TR", true);
            Bitis = DateTime.Parse(value, pv);
        }
    }
    
    private TarihFormati()
    {
    }
    /// <summary>
    ///Nesneyi olusturmak için çagirilacak metod static olarak tanimlanmistir. 
    ///Bu metod, bu türden bi nesne olusturulup olusturulmadigini kontrol eder.
    ///Olusturulmus ise eski degeri gönderir, olusturulmamis ise tanimalama islemini yapar.
    /// </summary>
    /// 
    
   //Projemizde her formda ortak olarak bulunan başlangıç ve bitiş tarihi alanlarını veritabanında kaydedilmek üzere Türkiye için formatladık.
    public static TarihFormati formatliVeriAl
    {
        get
        {
            if (db == null)
                db = new Veritabani();
            return db;
        }
    }

    public DateTime Baslangic { get; set; }
    public DateTime Bitis { get; set; }



}
