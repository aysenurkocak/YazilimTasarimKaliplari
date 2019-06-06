using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data;
using MetroFramework.Controls;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FaturaEkle : MetroForm
    {

        System.Data.DataTable dt = new System.Data.DataTable();
      
        public int Typ { get; set; }

        public FaturaEkle(int type)
        {
            StyleManager = msmMain;
            InitializeComponent();
            
            //drbLokasyon.DataSource = new BindingSource(DbIslemlerim.S_Tanimlar(1).ToList(), null);
            //drbLokasyon.DisplayMember = "Ad";
            //drbLokasyon.ValueMember = "Id";
                
            //drbFirma.DataSource = new BindingSource(DbIslemlerim.S_Tanimlar(3).ToList(), null);
            //drbFirma.DisplayMember = "Ad";
            //drbFirma.ValueMember = "Id";

            //drpOdeme.DataSource = new BindingSource(DbIslemlerim.S_Tanimlar(4).ToList(), null);
            //drpOdeme.DisplayMember = "Ad";
            //drpOdeme.ValueMember = "Id";

            txtTarih.Mask = "00/00/0000";
           
            Typ = type;
            FaturaDoldur();

        }
        //

        private void btnKaydet_Click(object sender, EventArgs e)
        {

   
            try
            {
                if (txtTutar.Text == "")
                    MessageBox.Show("Eksik alanları doldurunuz !", "HATA");
                else
                {
                    //DbIslemlerim.C_Fatura(Typ, Convert.ToInt16(drpOdeme.SelectedValue), Convert.ToDecimal(txtTutar.Text), Convert.ToInt16(drbFirma.SelectedValue), Convert.ToInt16(drbLokasyon.SelectedValue),Convert.ToDateTime(txtTarih.Text), FaturaNo.Text);
                    MessageBox.Show("Faturanız kaydedildi !", "BAŞARILI");
                    FaturaDoldur();

                    //Fatura product = new Fatura();
                    //product.Attach(new CustomerObserver());
                    //product.ChangeFatura();

                    S_Fatura_Result F = new S_Fatura_Result();
                    F.FaturaNo = FaturaNo.Text;
                    F.Firma = drbFirma.SelectedText;
                    F.Lokasyon =drbLokasyon.SelectedText;
                    F.OdemeTipi = drpOdeme.SelectedText;
                    F.Tutar = Convert.ToDecimal(txtTutar.Text);

                    FaturaIslemleri FaturaBilgisi = new FaturaIslemleri();
                    Fatura Iletisim = FaturaBilgisi.FactoryMethod(FaturaTipleri.İletisim);

                    S_Fatura_Result YeniFatura = Iletisim.Getir(F);
                    SqlCommand cmd = new SqlCommand("C_Fatura", Veritabani.veritabaninaBaglan);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Tip", Typ));
                    cmd.Parameters.Add(new SqlParameter("@OdemeTipi", drpOdeme.SelectedText));
                    cmd.Parameters.Add(new SqlParameter("@FaturaNo", FaturaNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@Tutar", Convert.ToDecimal(txtTutar.Text)));

                    Veritabani.veritabaninaBaglan.Open();
                    cmd.ExecuteNonQuery();
                    Veritabani.veritabaninaBaglan.Close();

                }

            }
            catch (Exception ex)
            {
                LogGoster LogKaydetVeGoster = new Adapter();
                LogKaydetVeGoster.txtKaydet();
            }
          
        }

        public Boolean SayiMi_3(String strVeri)
        {
            if (String.IsNullOrEmpty(strVeri) == true)
            {
                return false;
            }
            else
            {
                Regex desen = new Regex("^[0-9]*$");
                return desen.IsMatch(strVeri);
            }
        }

        private void drbLokasyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = drbLokasyon.SelectedValue.ToString();  
        }

        public void FaturaDoldur()
        {
            if (Typ == 1)
            {
                Text = "Malzeme Ekle";
            }
            else if (Typ == 2)
            {
                Text = "Yemek Ekle";
            }

            else if (Typ == 3)
            {
                Text = "Konaklama Ekle";
            }
            else
            {
                Text = "İletişim Ekle";
            }
            //List<S_Fatura_Result> faturalar = new List<S_Fatura_Result>();
          
            //{

            //    faturalar = DbIslemlerim.S_Fatura(Typ, 0, null, null).ToList();
            //    gridFatura.Rows.Clear();
            //    gridFatura.Refresh();


            //    gridFatura.ColumnCount = 7;
            //    gridFatura.Columns[0].Name = "Fatura No";
            //    gridFatura.Columns[1].Name = "Lokasyon";
            //    gridFatura.Columns[2].Name = "Firma Adı";
            //    gridFatura.Columns[3].Name = "Tutar";
            //    gridFatura.Columns[4].Name = "Ödeme Tipi";
            //    gridFatura.Columns[5].Name = "Tarih";
            //    gridFatura.Columns[6].Name = "ID";

            //    foreach (S_Fatura_Result i in faturalar)
            //    {
            //        string[] row = new string[] {
            //           i.FaturaNo,
            //           i.Lokasyon,
            //           i.Firma,
            //           i.Tutar.ToString(),
            //           i.OdemeTipi,
            //           i.Tarih.Value.ToShortDateString(),
            //           i.Id.ToString()
            //        };
            //        gridFatura.Rows.Add(row);
            //    }
            //    gridFatura.Columns[6].Visible = false;
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Invoker invoker = new Invoker();
            invoker.KomutEkle(new ExcelKomut());
            invoker.KomutEkle(new WordKomut());
            invoker.TumunuCalistir(gridFatura);

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FaturaDoldur();
           
        }
        
        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
            & e.KeyChar != ',')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }
        private string currentText;

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.Length > 0)
            {
                float result;
                bool isNumeric = float.TryParse(this.Text, out result);

                if (isNumeric)
                {
                    currentText = this.Text;
                }
                else
                {
                    this.Text = currentText;
                }
            }
            base.OnTextChanged(e);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridFatura.SelectedRows.Count != 0)
            {
                try
                {
                    DataGridViewRow row = this.gridFatura.SelectedRows[0];
                    string Id = row.Cells["Id"].Value.ToString();
                    //DbIslemlerim.D_Faturalar(0, Convert.ToInt16(Id));
                    MessageBox.Show("Fatura Silindi", "BAŞARILI");
                    FaturaDoldur();
                }
                catch(Exception EXC)
                { }
            }
        }
    }
}
