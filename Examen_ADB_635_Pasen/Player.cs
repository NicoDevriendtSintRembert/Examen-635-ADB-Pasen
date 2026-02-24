using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADB_635_Pasen
{
    internal class Player
    {
        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        private string _familienaam;

        public string Familienaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }

        private int _boardAttempts;

        public int BoardAttempts
        {
            get { return _boardAttempts; }
            set { _boardAttempts = value; }
        }

        public Player(string naam, string voornaam)
        {
            Naam = voornaam;
            Familienaam = naam;
            BoardAttempts = 0;
        }


    }
}


