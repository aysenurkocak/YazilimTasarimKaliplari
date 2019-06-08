using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface Iterator<T>
    {

        T SuAnkiOge { get; }
        //3. Varsa bir sonraki ögeye geç. 
        bool BirSonraki();
    }

    //Her taşıyıcı, hem koleksiyon hem de yineleyici nesneyi bir arada barındırır.
    public interface ITasiyici<T>
    {
        Iterator<T> YineleyiciOlustur();
    }


    //Yinelenecek koleksiyon ögesi:
    public class Kategori
    {
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
    }

    //Yinelenecek koleksiyon ögesi:
    public class Kategori
    {
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class KategoriTasiyici : ITasiyici<Kategori>
    {
        //Kategori Koleksiyonu.
        public List<Kategori> TumKategoriler { get; } = new List<Kategori>();

        //koleksiyona kategori ekle
        public void KategoriEkle(Kategori kategori) => TumKategoriler.Add(kategori);

        public int KategoriSayisi { get => TumKategoriler.Count; }
        //Koleksiyonun yineleyicisi
        public Iterator<Kategori> YineleyiciOlustur()
        {
        }
    }

//Kategori yineleyici sınıfı
    public class KategoriIterator : Iterator<Kategori>
    {
        //Çalışılacak taşıyıcı nesne:
        private KategoriTasiyici kategoriTasiyici;
        //taşıyıcı nesne, constructor'da belirtiliyor:
        public KategoriIterator(KategoriTasiyici kategoriTasiyici)
        {
            this.kategoriTasiyici = kategoriTasiyici;
        }

        //bir ögeden diğerine geçişi yöneten algoritmanın ana noktası, koleksiyonun aktif index değerini bellekte tutmak:
        private int aktifIndex = 0;

        public Kategori SuAnkiOge { get; private set; }

        public bool BirSonraki()
        {
            if (aktifIndex < kategoriTasiyici.KategoriSayisi)
            {
                SuAnkiOge = kategoriTasiyici.TumKategoriler[aktifIndex++];
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public Iterator<Kategori> YineleyiciOlustur()
    {
        //TODO 1: Yineleyiciyi döndür.
        return new KategoriIterator(this);
    }

}
