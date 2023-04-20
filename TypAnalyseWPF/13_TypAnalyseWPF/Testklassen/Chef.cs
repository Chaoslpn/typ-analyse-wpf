using System;

namespace TypAnalyseWPF
{
    public class Chef : Mitarbeiter
    {
        public Auto Dienstfahrzeug { get; set; } = null;

        public Chef() : base()
        {
        }

        public Chef(String vn, String nn, double g, DateTime gebDatum) : base(vn, nn, g, gebDatum)
        {
        }

        public override void ErhoeheGehalt(double betrag)
        {
            base.ErhoeheGehalt(2 * betrag);
        }

        public override string ToString()
        {
            if (this.Dienstfahrzeug == null)
                return base.ToString() + " Dienstfahrzeug: keines";
            else
                return base.ToString() + " Dienstfahrzeug: " + this.Dienstfahrzeug.ToString();
        }
    }
}
