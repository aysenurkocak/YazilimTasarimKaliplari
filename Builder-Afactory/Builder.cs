        private void AnaForm_Load(object sender, EventArgs e)
        {
            ////Proje ��in
            ReportInfo info = new ReportInfo();
            info.Title = "Gider Grafi�i";
            
            info.Expenses = new List<string>();

            //Faturalar�n toplam tutarlar� veritaban�nda bir SP den liste halide geliyor biz bunlar� grafik ile g�steriyoruz.
            AsyaDbEntities DbIslemlerim = new AsyaDbEntities();
            List<S_Grafik_Result> GrafikList = new List<S_Grafik_Result>();
            GrafikList  = DbIslemlerim.S_Grafik().ToList();
            decimal sayac = 0;
            foreach(S_Grafik_Result x in GrafikList)
            {
                if(x.Ucret != null)
                {
                    //Hangi fatura ve toplam tutar� ne !!!
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
                lblGrafik.Text = "Kay�tl� Fatura  �creti Toplam� : " + sayac;
                info.TotalCost = sayac;
            }
            
            ReportBuilderBase builder = new DivBasedReportBuilder(info);
            ReportManager reportManager = new ReportManager(builder);

            string str = reportManager.Build();
           
        }