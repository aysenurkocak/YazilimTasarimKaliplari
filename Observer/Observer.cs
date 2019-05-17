using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Fatura
    {
        // Gözlemleyicilerimizi tutacağımız listemiz.
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            // Herhangi bir değişiklik olduğunda gözlemleyicilerimizin Update metotunu tetikleterek istenilen aksiyonu gerçekleştirebiliriz. Örneğin: Kullanıcılara e-posta atmak gibi düşünebilirsiniz.
            _observers.ForEach(o => { o.Update(); });
        }

        public void ChangeFatura()
        {
                // Fatura değiştirildiğinde gözlemcilerimize bildiriyoruz.
            this.Notify();
        }
    }
    /// <summary>
    /// Observer - Soyut sınıfımız.
    /// Soyutlamamızın nedeni ise birden fazla sınıf tarafındanda takip edilmesini sağlamak.
    /// </summary>
    abstract class Observer
    {
        // Herhangi bir değişimde gözlemleyiciler tarafından yapılması istenilen aksiyonlar.
        public abstract void Update();
    }

    /// <summary>
    /// ConcreteObserver - Gerçek takip eden nesnemiz.
    /// </summary>
    class CustomerObserver : Observer
    {
        //Fatura geldiğinde gökhana mail yolluyoruz.
        public override void Update()
        {

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("aysenurkocak6635@gmail.com");
            ePosta.To.Add("GokhanAsyaInsaat@gmail.com");
            ePosta.Subject = "Yeni Fatura";
            ePosta.Body = "Yeni bir fatura geldi, programı kontrol et";
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("aysenurkocak6635@gmail.com", "Asya123");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = false;
            smtp.Send(ePosta);
            MessageBox.Show("Yeni eklenen faturanın bilgisi mail olarak sunuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

}
//Kullanımı
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
            }
          
        }

