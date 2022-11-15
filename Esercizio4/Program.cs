using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Per vedere list del calcolo spread del Paese fate un enter. ");
            Console.ReadKey();
            EuroCentralBanc euroCentralBanc = new EuroCentralBanc();
            PaeseEuroZona paeseEuroZona1 = new PaeseEuroZona("Italia","Euro",3);
            euroCentralBanc.AddPaese(paeseEuroZona1);
            PaeseEuroZona paeseEuroZona2 = new PaeseEuroZona("Spagnia", "Euro", 4);
            euroCentralBanc.AddPaese(paeseEuroZona2);
            PaeseEuroZona paeseEuroZona3 = new PaeseEuroZona("Germania", "Euro", 5);
            euroCentralBanc.AddPaese(paeseEuroZona3);
            euroCentralBanc.DisplaySpread();


            Console.ReadKey();


        }   
    }
    public class EuroCentralBanc
    {
      
        public string CapitaleSociale { get; set; }
        public string PartitaIva { get; set; }
        public string Indirizzo { get; set; }
        public int NumeroDipendenti { get; set; }

        PaeseEuroZona[] paesi = new PaeseEuroZona[19];
        public void AddPaese(PaeseEuroZona paese)
        {
            for(int i = 0; i < paesi.Length; i++)
            {
                if (paesi[i] == null)
                {
                    paesi[i] = paese;
                    break;
                }
               
            }
        }
        public void DisplaySpread()
        {
            foreach(PaeseEuroZona paeseEuroZona in paesi)
            {
                if (paeseEuroZona != null)
                {
                    Console.WriteLine("Il valore attuale dello spread del " + paeseEuroZona.Nome + " è: "+paeseEuroZona.Spread);
                }
            }    
        }
    }
    public class PaeseEuroZona
    { 
        public PaeseEuroZona(string nome,string moneta,double tassoDiInteresse)
        {
            Nome = nome;
            Moneta = moneta;
            TassoDiInteresse = tassoDiInteresse;
            Spread=CalcoloSpread();

        }
       
        public string Nome { get; set; }
        public string Moneta { get; set; }
        public double TassoDiInteresse { get; set; }
        public double Spread { get; set; }
        private double CalcoloSpread()
        {
           return (TassoDiInteresse -1) * 100;
        }
    }
}
