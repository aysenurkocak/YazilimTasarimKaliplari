        private void AnaForm_Load(object sender, EventArgs e)
        {
            ////Proje Ýçin
            ReportInfo info = new ReportInfo();
            info.Title = "Gider Grafiði";
            
            info.Expenses = new List<string>();

            //Faturalarýn toplam tutarlarý veritabanýnda bir SP den liste halide geliyor biz bunlarý grafik ile gösteriyoruz.
            AsyaDbEntities DbIslemlerim = new AsyaDbEntities();
            List<S_Grafik_Result> GrafikList = new List<S_Grafik_Result>();
            GrafikList  = DbIslemlerim.S_Grafik().ToList();
            decimal sayac = 0;
            foreach(S_Grafik_Result x in GrafikList)
            {
                if(x.Ucret != null)
                {
                    //Hangi fatura ve toplam tutarý ne !!!
                    info.Expenses.Add(x.Adi + " (" + Decimal.Round(Convert.ToDecimal(x.Ucret), 2) + ")", Decimal.Round(Convert.ToDecimal(x.Ucret), 2));
                    sayac = sayac + Decimal.Round(Convert.ToDecimal(x.Ucret),2);
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
                lblGrafik.Text = "Kayýtlý Fatura  Ücreti Toplamý : " + sayac;
                info.TotalCost = sayac;
            }
            
            ReportBuilderBase builder = new DivBasedReportBuilder(info);
            ReportManager reportManager = new ReportManager(builder);

            string str = reportManager.Build();
           
        }