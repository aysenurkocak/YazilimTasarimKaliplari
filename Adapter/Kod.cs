using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //Fonksiyonumuz kullanıcıya hata olduğunda messagebox ile bildiriyor.
    class LogGoster
    {
        public virtual void txtKaydet()
        {
            MessageBox.Show("Hata !", "Bilgi");
        }
    }

    //Messagebox ile bildirim yetersiz geliyor, Hatanın oluştuğu tarihi log txt içinde kayıt altına almak istiyoruz
    class logKaydet
    {
        public void LogKayit()
        {

            string dosya_yolu = @"C:\Log.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "tarihinde hata oluşmuştur.");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }

    //Yeni fonksiyonumuzu adapte ediyoruz

    class Adapter : LogGoster
    {
        private logKaydet _adaptee = new logKaydet();

        public override void txtKaydet()
        {
            _adaptee.LogKayit();
        }
    }
}

//Proje içinde Örnek kullanımı

  private void btnKaydet_Click(object sender, EventArgs e)
        {

   
            try
            {
                if (txtTutar.Text == "")
                    MessageBox.Show("Eksik alanları doldurunuz !", "HATA");
                else
                {
                    DbIslemlerim.C_Fatura(Typ, Convert.ToInt16(drpOdeme.SelectedValue), Convert.ToDecimal(txtTutar.Text), Convert.ToInt16(drbFirma.SelectedValue), Convert.ToInt16(drbLokasyon.SelectedValue),Convert.ToDateTime(txtTarih.Text), FaturaNo.Text);
                    MessageBox.Show("Faturanız kaydedildi !", "BAŞARILI");
                    FaturaDoldur();
                    
                    Fatura product = new Fatura();
                    product.Attach(new CustomerObserver());
                    product.ChangeFatura();
                }

            }
            catch (Exception ex)
            {
		//İşlem esnasında bir hata oluşursa hem messagebox ile gösterilecek hemde bir txt de hata kayıtlı hale gelecek.
                LogGoster LogKaydetVeGoster = new Adapter();
                LogKaydetVeGoster.txtKaydet();
            }
          
        }


