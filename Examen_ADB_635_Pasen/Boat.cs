using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADB_635_Pasen
{
    internal class Boat
    {
        public string Naam { get; set; }
        public int AantalCellen { get; set; }


        public Boat(string naam, int aantalCellen)
        {
            Naam = naam;
            AantalCellen = aantalCellen;
        }
    }
}