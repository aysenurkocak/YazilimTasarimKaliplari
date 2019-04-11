using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    /// <summary>
    /// Asya inşaata ait 12 kalem fatura giderlerinin kaydını tuttuğumuz projemizde (yemek, kira, vergi vs) Id,ödeme tipi, fatura tutarı, tarihi alanları ortaktır.
    /// Diğer fatura tipleri bu genel prototipten türeyecektir.
    /// </summary>
    /// 

    class FaturaListesi
    {
        public List<S_Araclar_Result> Arac;
        public FaturaListesi(List<S_Araclar_Result> Fatura)
        {
            this.Arac = Fatura;
        }

        public List<S_Kira_Result> Kira;
        public FaturaListesi(List<S_Kira_Result> Fatura)
        {
            this.Kira = Fatura;
        }
        public List<S_Vergi_Result> Vergi;
        public FaturaListesi(List<S_Vergi_Result> Fatura)
        {
            this.Vergi = Fatura;
        }
    }
    class FaturaGenel
    {
        public int Id { get; set; }
        public string OdemeTipi { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<System.DateTime> FaturaTarih { get; set; }
        public Nullable<decimal> Tutar { get; set; }
        public FaturaListesi _FaturaDigerBilgiler;

        public FaturaGenel ShallowCopy()
        {
            return (FaturaGenel)this.MemberwiseClone();
        }
        public FaturaGenel DeepCopy()
        {
            FaturaGenel deep = (FaturaGenel)this.MemberwiseClone();
            deep._FaturaDigerBilgiler = new FaturaListesi(this._FaturaDigerBilgiler.Arac);
            return deep;
        }

    }
}
