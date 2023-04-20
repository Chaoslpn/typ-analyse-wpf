using System;

namespace TypAnalyseWPF
{
    public class Mitarbeiter
    {
        // Konstanten
        public const double MAXIMAL_GEHALT = 20000;

        public static int MitarbeiterCounter = 0;


        public int Id { get; set; }


        public String Vorname { get; set; }

        public String Nachname { get; set; }

        private double _gehalt;
        // Property "Gehalt"
        public double Gehalt
        {
            get
            {
                return this._gehalt;
            }
            set
            {
                if (value > MAXIMAL_GEHALT)
                    throw new Exception("Gehalt zu hoch");

                if (value < Mindestgehalt)
                    throw new Exception("Gehalt zu niedrig");

                this._gehalt = value;
            }
        }

        private static double _mindestgehalt = 500;


        public static double Mindestgehalt
        {
            get
            {
                return Mitarbeiter._mindestgehalt;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Mindestgehalt war negativ");

                if (value > Mitarbeiter.MAXIMAL_GEHALT)
                    throw new Exception("Mindestgehalt war höher als Maximalgehalt");

                Mitarbeiter._mindestgehalt = value;
            }
        }


        private DateTime _gebdat;
        //2. property mit get- und set-Accesor definieren

        public DateTime Gebdat
        {
            get { return _gebdat; }
            set
            {
                // .Date ruf nur das Datum (mit Uhrzeit 00:00 ab)
                if (value.Date > DateTime.Today)
                    throw new Exception("Geburtsdatum darf nicht in der Zukunft liegen");

                _gebdat = value.Date;
            }
        }

        public int Alter
        {
            get
            {
                int alter = DateTime.Today.Year - Gebdat.Year;

                if (Gebdat.Month > DateTime.Today.Month || DateTime.Today.Month == Gebdat.Month && Gebdat.Day > DateTime.Today.Day)
                {
                    alter--;
                }
                return alter;
            }
        }



        //private Mitarbeiter _stellvertreter;
        //[ForeignKeyAttribut("Id")]
        //public Mitarbeiter Stellvertreter
        //{
        //  get
        //  {
        //    return _stellvertreter;
        //  }

        //  set
        //  {
        //    // Prüfung ob zugewiesene Referenz (=value) mit "mir selbst" identisch ist
        //    if (value == this)
        //      throw new Exception("Stellvertreter ist mit Mitarbeiter identisch!");

        //    if (this.Equals(value))
        //      throw new Exception("Stellvertreter hat selbe Daten wie der Mitarbeiter!");

        //    _stellvertreter = value;
        //  }
        //}




        public Mitarbeiter(String vn, String nn, double g, DateTime gebDatum)
        {
            // _vorname = vn; besser über property zugreifen!
            Vorname = vn;
            Nachname = nn;
            Gehalt = g;
            Gebdat = gebDatum;

            this.Id = ++MitarbeiterCounter;
        }


        public Mitarbeiter() : this("unbekannt", "unbekannt", Mindestgehalt, new DateTime(1, 1, 1))
        {
        }

        // durch virtual wird die späte Bindung aktiviert
        // d.h. die Methode kann in abgeleiteten Klassen überschrieben
        // werden
        public virtual void ErhoeheGehalt(double betrag)
        {
            if (betrag <= 0)
            {
                Exception e = new Exception("Betrag beim Erhöhen muss positiv sein!");
                throw e;
            }

            // this.Gehalt = this.Gehalt + betrag;
            // Kurzform:
            this.Gehalt += betrag;
        }


        public override string ToString()
        {
            return $"{this.Vorname} {this.Nachname} {this.Gebdat.ToShortDateString()} {this.Gehalt} {this.Alter}";
        }

        public override bool Equals(object obj)
        {
            // Verwandle die object-Referenz in eine Mitarbeiter Referenz
            Mitarbeiter m = obj as Mitarbeiter;

            if (m == null) // d.h. der cast hat nicht geklappt!
                return false;

            // Selbst definiertes Kriterium:
            // zwei Mitarbeiter sind identisch, wenn der Nachname identisch ist
            if (this.Nachname == m.Nachname)
                return true;
            else
                return false;
        }
    }
}
