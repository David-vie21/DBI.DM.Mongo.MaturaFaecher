using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBI.MongoRepoGeneric.Tests
{
    [BsonCollection("class")]
    public class Class : Document
    {
        public string Name { get; set; }
        public Pruefung[] Pruefung { get; set; }
    }

    public class Pruefung : Document
    {
        public string Schueler { get; set; }
        public Fach Fach { get; set; }
    }

    public class Fach : Document
    {
        public Diplomarbeit Diplomarbeit { get; set; }
        public AngMath AngMath { get; set; }
        public Englisch Englisch { get; set; }
        public Deutsch Deutsch { get; set; }
        public Fachtheorie Fachtheorie { get; set; }
        public Schwerpunktfach Schwerpunktfach { get; set; }
        public Wahlpunktfach Wahlpunktfach { get; set; }
    }
    public class Diplomarbeit : Document
    {
        public string Lehrer { get; set; }
    }

    public class AngMath : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Englisch : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Deutsch : Document
    {
        public string Lehrer { get; set; }
        public string Note { get; set; }
    }

    public class Fachtheorie : Document
    {
        public string Lehrer { get; set; }
        public string fach { get; set; }
        public int Note { get; set; }
        public bool muedlich { get; set; }

    }

    public class Schwerpunktfach : Document
    {
        public string Lehrer { get; set; }
        public string Fach { get; set; }
        public bool muedlich { get; set; }
    }

    public class Wahlpunktfach : Document
    {
        public string Lehrer { get; set; }
        public string Fach { get; set; }
        public bool muedlich { get; set; }
    }

}
