using System;
using MetroFramework.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class AnaForm : MetroForm
    {
        private DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();


        public void GrafikOlustur()
        {
        
        //Veritabanı.Cs de oluşturduğumuz singleton yapısını burada kullanıyoruz, tanımlamadan direkt .
        
            SqlCommand cmd = new SqlCommand("S_Grafik", Veritabani.veritabaninaBaglan);
            cmd.CommandType = CommandType.StoredProcedure;
            Veritabani.veritabaninaBaglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Veritabani.veritabaninaBaglan.Close();

            //Faturaların toplam tutarları veritabanında bir SP den liste halide geliyor biz bunları grafik ile gösteriyoruz.
            List<S_Grafik_Result> GrafikList = new List<S_Grafik_Result>();
            GrafikList = ds.Tables[0].AsEnumerable().Select(dataRow => new S_Grafik_Result {
                Adi = dataRow.Field<string>("Adi"),
                Ucret = dataRow.Field<decimal>("Ucret")
            }).ToList();

            decimal sayac = 0;
            //Grafiği yenilemek için
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            foreach (S_Grafik_Result x in GrafikList)
            {
                if (x.Ucret != null)
                {
                    sayac = sayac + Decimal.Round(Convert.ToDecimal(x.Ucret), 2);
                    chart1.Series["Series1"].Points.AddXY(
                    x.Adi + " (" + Decimal.Round(Convert.ToDecimal(x.Ucret), 2) + ")", Decimal.Round(Convert.ToDecimal(x.Ucret), 2)
                    );
                }
            }
           
            if (sayac <= 0)
                lblGrafik.Visible = false;
            else
            {
                lblGrafik.Visible = true;
                lblGrafik.Text = "Kayıtlı Fatura  Ücreti Toplamı : " + sayac;

            }
        }

        }
    }
}
