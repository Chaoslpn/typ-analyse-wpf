using System;

namespace TypAnalyseWPF
{
    public class Auto
    {
        public String Marke { get; set; }
        public String Typ { get; set; }
        public int Baujahr { get; set; } = 1900;
        public int Fahrgestellnr { get; }
        public static int AnzAutos { get; set; } = 42;

        public Auto()
        {
        }

        public Auto(String m, String t)
        {
            this.Marke = m;
            this.Typ = t;
        }

        public Auto(String m, String t, int bj)
        {
            // im Konstruktor dürfen readonly Felder geschrieben werden
            this.Baujahr = bj;
            this.Marke = m;
            this.Typ = t;
        }

        public override String ToString()
        {
            return this.Marke + " " + this.Typ + " Baujahr:" + this.Baujahr;
        }
    }
}
