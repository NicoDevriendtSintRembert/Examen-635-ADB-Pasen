using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADB_635_Pasen
{
    internal class Board
    {

        private int _aantalRijen;

        public int AantalRijen
        {
            get { return _aantalRijen; }
        }

        private int _aantalKolommen;
        public int AantalKolommen
        {
            get { return _aantalKolommen; }
        }

        private int _aantalCellenToHit;

        public int AantalCellenToHit
        {
            get { return _aantalCellenToHit; }
            set { _aantalCellenToHit = value; }
        }

        private Cell[,] _cellen;

        public Cell[,] Cellen
        {
            get { return _cellen; }
        }

        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }




        public bool HideBoats { get; set; }

        public Board(int aantalRijen, int aantalKolommen)
        {
            _aantalKolommen = aantalKolommen;
            _aantalRijen = aantalRijen;
            _cellen = new Cell[aantalRijen, aantalKolommen];
            genereerEmptyAlleCellen();
        }

        private void genereerEmptyAlleCellen()
        {
            for (int rij = 0; rij < AantalRijen; rij++)
            {
                for (int kol = 0; kol < AantalKolommen; kol++)
                {
                    Cellen[rij, kol] = new Cell();
                }
            }
        }
        public void FireOnTarget(char kolom, int rij)
        {
            Cell targetCell = Cellen[rij - 1, kolom - 'A'];
            // ===== START STUDENT CODE =====
            // Volgens de rij en kolom die wordt mee gegeven worden
            // volgende acties uitgevoerd
            // rij/kol = Boot:
            //           Melding: Je hebt een boot geraakt
            //           Markeer de cel als Raak
            //           Verminder het aantalCellenToHit met 1
            // rij/kol = Leeg:
            //           Melding: Helaas geen boot
            //           Markeer de cel als Mis
            // rij/kol = Mis:
            //           Melding:Helaas geen boot, deze cel heb je al gecontroleerd
            // rij/kol = Raak:
            //           Melding:Boot, maar je hebt deze cel heb je al gecontroleerd
            // Gebruik switch(targetCell.Status) en de enum statusCell.
            // ===== END STUDENT CODE =====

            player.BoardAttempts++;
            tekenBoard();
            Console.WriteLine("Druk op een toets om verder te spelen");
            Console.ReadLine();

        }

        private void placeBoatsOnBoardByComputer(List<Boat> boats)
        {
            //Deze methode zorgt ervoor dat alle schepen automatisch en willekeurig op het bord van de computer worden geplaatst.
            //De speler mag de positie van deze schepen niet kennen.
            assignPlayerToBoard(true);
            Random objRandom = new Random();
            foreach (var boat in boats)
            {
                bool boatGeplaatst = false;
                while (boatGeplaatst == false)
                {
                    // ===== START STUDENT CODE =====
                    // Bepaal at random een kolom volgens het speelbord 
                    // Bepaal at random een rij volgens het speelbord
                    // Bepaal at random of de boot verticaal of horizontaal wordt geplaatst
                    // 
                    //Plaats het schip op het bord herhaal deze stappen totdat de plaatsing geldig is.
                    //Maak gebruik van de placeBoatByComputer methode()
                    // ===== END STUDENT CODE =====
                }

            }
        }

        public void placeBoatsOnBoard(List<Boat> boats)
        {
            assignPlayerToBoard(false);
            foreach (var boat in boats)
            {
                bool boatGeplaatst = false;
                while (boatGeplaatst == false)
                {
                    Console.WriteLine($"Op welke plaats wil je de {boat.Naam} plaatsen");

                    char column = helper.askColumnToUser(AantalKolommen);
                    int row = helper.askRowToUser(AantalRijen);
                    bool isHorizontal = helper.askPositionToUser();

                    boatGeplaatst = placeBoat(column, row, boat, isHorizontal);
                }
                tekenBoard();
            }
        }

        private void assignPlayerToBoard(bool askUserName = false)
        {
            Console.Clear();
            if (!askUserName)
            {
                Player = new Player("COMPUTER", "");
            }
            else
            {
                Console.Write("Wat is uw voornaam ?: ");
                string voornaam = Console.ReadLine();
                Console.Write("Wat is uw familienaam ?: ");
                string familienaam = Console.ReadLine();
                Player = new Player(familienaam, voornaam);
            }
            Console.Clear();
        }

        public bool placeBoat(char startColumn, int startRow, Boat boat, bool isHorizontal)
        {

            bool boatGeplaatst = false;
            if (!canBoatPlacedOnBoard(boat, startColumn, startRow, isHorizontal))
            {
                Console.WriteLine("Deze boot kan niet geplaatst worden,boot eindigt buiten speelveld");
            }
            else
            {
                if (!areCellsAreFreeForPlacingBoat(boat, startRow, startColumn, isHorizontal))
                {
                    Console.WriteLine("De boot kan niet geplaatst worden, er is een overlap met een andere boot");
                }
                else
                {
                    placeBoatOnCells(startColumn, startRow, boat, isHorizontal);
                    boatGeplaatst = true;
                }
            }
            return boatGeplaatst;

        }

        public bool placeBoatByComputer(char startColumn, int startRow, Boat boat, bool isHorizontal)
        {

            bool boatGeplaatst = false;
            if (canBoatPlacedOnBoard(boat, startColumn, startRow, isHorizontal) && areCellsAreFreeForPlacingBoat(boat, startRow, startColumn, isHorizontal))
            {
                placeBoatOnCells(startColumn, startRow, boat, isHorizontal);
                boatGeplaatst = true;
            }

            return boatGeplaatst;

        }
        public void tekenBoard()
        {
            Console.Clear();
            Console.WriteLine($"{player.Naam} {player.Familienaam}");
            tekenHeader();

            for (int rij = 0; rij < AantalRijen; rij++)
            {
                Console.Write((rij + 1).ToString().PadLeft(2, ' '));

                for (int kol = 0; kol < AantalKolommen; kol++)
                {
                    Console.Write("  ");

                    // ===== START STUDENT CODE =====
                    // Bepaal het teken dat moet afgedrukt worden op het speelbord
                    // Cell bevat een boot --> Boten moeten verborgen zijn: Druk .
                    // Cell bevat een boot --> Boten mogen zichtbaar zijn: Druk B
                    // Cell is leeg --> Druk .
                    // Cell is fout shot --> Druk een rode X
                    // Cell is raak shot --> Druk groene V
                    // 
                    // Vergeet niet Console.ResetColor() na een gekleurde output
                    // ===== END STUDENT CODE =====


                }
                Console.WriteLine();
            }
        }

        private void tekenHeader()
        {
            Console.Write("  ");
            char kolomHeader = 'A';
            for (int i = 1; i <= AantalKolommen; i++)
            {
                Console.Write("  " + kolomHeader);
                kolomHeader = (char)(kolomHeader + 1);
            }
            Console.WriteLine();
        }


        private bool canBoatPlacedOnBoard(Boat boat, char startColumn, int startRow, bool isHorizontal)
        {
            // ===== START STUDENT CODE =====
            // TODO:
            // 1) Bepaal of de boot volledig op het bord past.
            //    - Horizontaal: startColumn ... startColumn + boot.AantalCellen - 1
            //    - Verticaal:   startRow ... startRow + boot.AantalCellen - 1
            // 2) Return true als het past, anders false.
            //
            // Tip:
            // - Last column = 'A' + AantalKolommen - 1
            // - Let op: startRow is 1-based, kolommen zijn letters.
            // ===== END STUDENT CODE =====
            // Zolang deze methode true teruggeeft, kan je boten buiten het bord plaatsen
            return true; // tijdelijke placeholder
        }

        private bool areCellsAreFreeForPlacingBoat(Boat boat, int startRow, char startColumn, bool isHorizontal)
        {
            // ===== START STUDENT CODE =====
            // TODO:
            // Controleer of alle cellen waar de boot zou komen nog leeg zijn (statusCell.Empty).
            // Return true als ALLE cellen leeg zijn, anders false.
            //
            // Tip:
            // - startRow is 1-based -> index in array is startRow - 1
            // - startColumn is letter -> index in array is startColumn - 'A'
            // - Bij horizontaal verandert de kolom, bij verticaal verandert de rij.
            // ===== END STUDENT CODE =====

            return true; // tijdelijke placeholder
        }

        private void placeBoatOnCells(char startColumn, int startRow, Boat boat, bool isHorizontal)
        {
            // ===== START STUDENT CODE =====
            // TODO:
            // Zet de juiste cellen op statusCell.Boot.
            // Vergeet daarna niet: updateAantalCellenToHit(boat);
            //
            // Tip:
            // - Maak GEEN nieuwe array, werk in Cellen[,]
            // - Gebruik een for-loop van i = 0 tot boat.AantalCellen - 1
            // ===== END STUDENT CODE =====
            updateAantalCellenToHit(boat);

        }

        private void updateAantalCellenToHit(Boat boat)
        {
            AantalCellenToHit += boat.AantalCellen;
        }

        public bool allBoatsSunk()
        {
            return AantalCellenToHit == 0;
        }
    }
}

