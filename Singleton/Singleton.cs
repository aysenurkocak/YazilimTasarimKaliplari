public class TarihFormati

 public class TarihFormati

    {
        //Singleton deseniyle olusturdugumuz sinif, olusturulan yerde sadece bir adet olabilir. Ayni türden ikinici degiskene izin vermez.
        //tanımlar
        private static TarihFormati db;

        public DateTime Baslangic;

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
       
        private TarihFormati()
        {
            Baslangic = DateTime.Now;
        }
        /// <summary>
        ///Nesneyi olusturmak için çagirilacak metod static olarak tanimlanmistir. 
        ///Bu metod, bu türden bi nesne olusturulup olusturulmadigini kontrol eder.
        ///Olusturulmus ise eski degeri gönderir, olusturulmamis ise tanimalama islemini yapar.
        /// </summary>
        /// 

        //Projemizde her formda ortak olarak bulunan başlangıç ve bitiş tarihi alanlarını veritabanında kaydedilmek üzere Türkiye için formatladık.
        public static TarihFormati formatliVeriAlI
        {
            get
            {
                if (db == null)
                    db = new TarihFormati();
                return db;
            }
        }

        public DateTime deger;
        public static TarihFormati getInstance()
        {
            return formatliVeriAlI;
        }

    }




Kullanımı:
Fatura Kaydederken kullanılan buton 
    private void metroButton1_Click(object sender, EventArgs e)
        {
           try
            {
                TarihFormati TarihTurkiye = TarihFormati.getInstance();

                if (txtTrafik.Text == "" || txtLastik.Text == "" || txtBakim.Text == "" || txtKasko.Text == "")
                    MessageBox.Show("Eksik alanları doldurunuz !", "HATA");
                else
                {
                    DbIslemlerim.C_Araclar(Convert.ToInt16(drbPlaka.SelectedValue), Convert.ToInt16(drpOdeme.SelectedValue), Convert.ToDecimal(txtTrafik.Text), Convert.ToDecimal(txtKasko.Text), Convert.ToDecimal(txtBakim.Text), Convert.ToDecimal(txtLastik.Text), TarihTurkiye.deger, "");
                    MessageBox.Show("Faturanız kaydedildi !", "BAŞARILI");
                    FaturaDoldur();
                }

            }
            catch (Exception ex)
            {
            }


        }

