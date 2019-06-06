using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Singleton Kullanım Örneği
    public class Veritabani

    {
        private static SqlConnection db = null; //instance

        private Veritabani()
        {
        }

        //Olusturulmus ise eski degeri gönderir, olusturulmamis ise tanimalama islemini yapar.

        public static SqlConnection veritabaninaBaglan
        {
         
            get
            {
                if (db == null)
                    db = new SqlConnection("data source=localhost;initial catalog=AsyaDb;persist security info=True;user id=sa;password=2019A;MultipleActiveResultSets=True;");

                return db;
            }
        }

        public static void Ac()
        {
            if (db != null)
                db.Open();
        }
        public static void Kapat()
        {
            if (db != null)
                db.Close();
        }
        
    }

}
