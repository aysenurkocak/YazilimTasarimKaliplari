class Creater
{
    public Fatura FactoryMethod(Faturalar FaturaTipi)
    {
        Fatura Fatura = null;
        switch (Fatura)
        {
            case Faturalar.Sgk:
                Fatura= new Sgk();
                break;
            case Faturalar.Kira:
                Fatura = new Kira();
                break;
            case Faturalar.Arac:
                Fatura= new Arac();
                break;
            case Faturalar.Personel:
                Fatura = new Personel();
                break;
        }
        return Fatura;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Creater creater = new Creater();
        Fatura Sgk_FATURASI = creater.FactoryMethod(Faturalar.Sgk);
        Fatura Kira_FATURASI = creater.FactoryMethod(Faturalar.Kira);
 
        Sgk_FATURASI.getFatura();
        Console.Read();
    }
}