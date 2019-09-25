using System;
using System.Collections.Generic;
using System.Text;

namespace Austausch
{
    public class CSVConfigTypen
    {
        public enum DezimalTrenner { Punkt, Komma };
        public enum DatenTrenner { Komma, Semikolon, Tab };

        public DezimalTrenner TrennerDezimal { get; set; }
        public DatenTrenner TrennerDaten { get; set; }

        public CSVConfigTypen()
        {

        }

        public CSVConfigTypen(DezimalTrenner dezimalTrenner, DatenTrenner datenTrenner)
        {
            TrennerDezimal = dezimalTrenner;
            TrennerDaten = datenTrenner;
        }
    }
}
