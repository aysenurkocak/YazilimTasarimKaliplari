
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Product Class
    class Faturalar
    {
        public string FaturaNo { get; set; }
        public string Lokaasyon { get; set; }
        public string Tarih { get; set; }
        public string FirmaAdi { get; set; }
        public double Tutar { get; set; }


    }
    //Builder
    abstract class IFaturaBuilder
    {
        protected Faturalar fatura;
        public Faturalar Fatura
        {
            get { return fatura; }
        }

        public abstract void SetFaturaNo();
        public abstract void SetLokaasyon();
        public abstract void SetTarih();
        public abstract void SetFirmaAdi();
        public abstract void SetTutar();
    }

    //ConcreteBuilder Class
    class KiraConcreteBuilder : IFaturaBuilder
    {
        public KiraConcreteBuilder()
        {
           fatura = new Faturalar();
        }
        public override void SetTarih() => Fatura.Tarih = "12.02.2019";
        public override void SetFaturaNo() => Fatura.FaturaNo = "12233ADHHF";
        public override void SetLokaasyon() => Fatura.Lokaasyon = "Beylükdüzü";
        public override void SetFirmaAdi() => Fatura.FirmaAdi = "Koç";
        public override void SetTutar() => Fatura.Tutar = 12.000;
    }
    //ConcreteBuilder Class
    class ÝletisimConcreteBuilder : IFaturaBuilder
    {
        public ÝletisimConcreteBuilder()
        {
            fatura = new Faturalar();
        }
        public override void SetTarih() => Fatura.Tarih = "12.02.2019";
        public override void SetFaturaNo() => Fatura.FaturaNo = "ytyuHF";
        public override void SetLokaasyon() => Fatura.Lokaasyon = "Maltepe";
        public override void SetFirmaAdi() => Fatura.FirmaAdi = "Aysur";
        public override void SetTutar() => Fatura.Tutar = 16.000;
    }
    //Director Class
    class FaturaUret
    {
        public void Uret(IFaturaBuilder Fatura)
        {
            Fatura.SetTutar();
            Fatura.SetFaturaNo();
            Fatura.SetLokaasyon();
            Fatura.SetFirmaAdi();
            Fatura.SetTarih();
        }
    }
}


//BUÝLDER PATTERN KULLANIMI

//IFaturaBuilder fatura = new KiraConcreteBuilder();
//FaturaUret uret = new FaturaUret();
//uret.Uret(fatura);
//fatura = new ÝletisimConcreteBuilder();