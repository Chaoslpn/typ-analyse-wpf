using System;

namespace TypAnalyseWPF
{
    public class Auszubildender : Mitarbeiter
    {
        public String Berufsschule { get; set; }
        public Auszubildender(String vn, String nn, double gehalt, DateTime gebDatum, String bs) : base(vn, nn, gehalt, gebDatum)
        {
            this.Berufsschule = bs;
        }

        public void PruefungBestanden()
        {
            // TODO muss noch implementiert werden
        }

        public override string ToString()
        {
            return base.ToString() + " Berufsschule: " + this.Berufsschule;
        }
    }
}
