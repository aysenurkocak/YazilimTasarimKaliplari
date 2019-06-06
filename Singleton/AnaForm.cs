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
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class AnaForm : MetroForm
    {
        private DataSet ds = new DataSet();
        System.Data.DataTable dt = new System.Data.DataTable();
        public event EventHandler SettingClosed;
        public static int sayac;
        public AnaForm()
        {
            sayac = 0;
            StyleManager = msmMain;
            InitializeComponent();

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            GrafikOlustur();
        }

        public void GrafikOlustur()
        {
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

        private void btnLokasyon_Click(object sender, EventArgs e)
        {
            Tanimlar lokasyon = new Tanimlar(1);
            lokasyon.Show();
        }

        private void btnSantiye_Click(object sender, EventArgs e)
        {
            Tanimlar santiye = new Tanimlar(2);
            santiye.Show();
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {
            Tanimlar santiye = new Tanimlar(3);
            santiye.Show();
        }
        private void btnMalzeme_Click(object sender, EventArgs e)
        {
            FaturaEkle Fatura = new FaturaEkle(1);
            Fatura.Show();
        }

        private void btnYemekhane_Click(object sender, EventArgs e)
        {
            FaturaEkle Fatura = new FaturaEkle(2);
           // Fatura.MdiParent = this;
            Fatura.Show();
        }

        private void btnKonaklama_Click(object sender, EventArgs e)
        {
            FaturaEkle Fatura = new FaturaEkle(3);
            Fatura.Show();
        }

        private void btnIletisim_Click(object sender, EventArgs e)
        {
            FaturaEkle Fatura = new FaturaEkle(4);
            Fatura.Show();
        }

       

        private void btnArac_Click(object sender, EventArgs e)
        {
           
        }

      
        private void plakaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tanimlar Plaka = new Tanimlar(5);
            Plaka.Show();
        }


        private void plakaGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guncelle Plaka = new Guncelle(5);
            Plaka.Show();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*Tutar alanına sadece rakamsal giriş yapabilirsiniz ve küsüratlar için , karakteri kullanabilirsiniz.","YARDIM");
        }

        private void ödemeTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tanimlar Odeme = new Tanimlar(4);
            Odeme.Show();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            //Raporlar R = new Raporlar();
            //R.Show();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //AnaForm_Load(sender, e);
        }

        public void ShowSettings()
        {
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            lnlClose.Visible = true;

            EventHandler handler = SettingClosed;
            if (handler != null) handler(this, e);
        }


        public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell
        {
            private bool _enabled;                // Is the button enabled
            private PushButtonState _buttonState; // What is the button state
            protected Image _buttonImageHot;      // The hot image
            protected Image _buttonImageNormal;   // The normal image
            protected Image _buttonImageDisabled; // The disabled image

            protected DataGridViewImageButtonCell()
            {
                // In my project, buttons are disabled by default
                _enabled = false;
                _buttonState = PushButtonState.Disabled;

                // Call the routine to load the images specific to a column.

            }

            // Button Enabled Property
            public bool Enabled
            {
                get
                {
                    return _enabled;
                }

                set
                {
                    _enabled = value;
                    _buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
                }
            }

            // PushButton State Property
            public PushButtonState ButtonState
            {
                get { return _buttonState; }
                set { _buttonState = value; }
            }

            // Image Property
            // Returns the correct image based on the control's state.
            public Image ButtonImage
            {
                get
                {
                    switch (_buttonState)
                    {
                        case PushButtonState.Disabled:
                            return _buttonImageDisabled;

                        case PushButtonState.Hot:
                            return _buttonImageHot;

                        case PushButtonState.Normal:
                            return _buttonImageNormal;

                        case PushButtonState.Pressed:
                            return _buttonImageNormal;

                        case PushButtonState.Default:
                            return _buttonImageNormal;

                        default:
                            return _buttonImageNormal;
                    }
                }
            }


        }
    }
}
