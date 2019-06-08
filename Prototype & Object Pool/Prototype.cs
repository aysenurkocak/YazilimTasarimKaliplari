using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   
    abstract class PrototypeOdeme
    {
        public abstract PrototypeOdeme Clone();
    }


    class Odeme : PrototypeOdeme
    {
        public int OdemeID { get; set; }
        public string OdemeAdi { get; set; }
        public string OdemeTuru { get; set; }
        public bool Durum { get; set; }

        //durum ödendi bilgisi
        public Odeme(int OdemeID, string OdemeAdi, string OdemeTuru, bool Durum)
        {
            this.OdemeID = OdemeID;
            this.OdemeAdi = OdemeAdi;
            this.OdemeTuru = OdemeTuru;
            this.Durum = Durum;
        }

        public override PrototypeOdeme Clone()
        {
            return this.MemberwiseClone() as PrototypeOdeme;
        }
    }

}
