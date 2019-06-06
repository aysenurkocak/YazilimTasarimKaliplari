using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    using System;
    abstract class Fatura
    {
        public abstract S_Fatura_Result Getir(S_Fatura_Result fatura);
    }

    class Malzeme : Fatura
    {
        public override S_Fatura_Result Getir(S_Fatura_Result fatura)
        {
            fatura.Type = 1;
            return fatura;
        }
    }
    class Yemek : Fatura
    {
        public override S_Fatura_Result Getir(S_Fatura_Result fatura)
        {
            fatura.Type = 2;
            return fatura;
        }
    }
    class İletisim : Fatura
    {
        public override S_Fatura_Result Getir(S_Fatura_Result fatura)
        {
            fatura.Type = 3;
            return fatura;
        }
    }

    class Konaklama : Fatura
    {
        public override S_Fatura_Result Getir(S_Fatura_Result fatura)
        {
            fatura.Type = 4;
            return fatura;
        }
    }

    class FaturaIslemleri
    {
        public Fatura FactoryMethod(FaturaTipleri FaturaTipi)
        {
            Fatura fatura = null;
            switch (FaturaTipi)
            {
                case FaturaTipleri.Konaklama:
                    fatura = new Konaklama();
                    break;
                case FaturaTipleri.Malzeme:
                    fatura = new Malzeme();
                    break;
                case FaturaTipleri.Yemek:
                    fatura = new Yemek();
                    break;
                case FaturaTipleri.İletisim:
                    fatura = new İletisim();
                    break;
            }
            return fatura;
        }
    }

    // Enumaration FactoryMethod’un hangi tipte nesne üreteceğine yardımcı olacaktır.
    enum FaturaTipleri
    {
        Malzeme,
        Yemek,
        Konaklama,
        İletisim
    }
}
