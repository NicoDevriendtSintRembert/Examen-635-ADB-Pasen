using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADB_635_Pasen
{
    internal static class helper
    {

        public static char askColumnToUser(int aantalKolommenBoard)
        {
            char kolom;

            Console.WriteLine("Welke kolom ?");
            string inputUser = Console.ReadLine().ToUpper();
            while (char.TryParse(inputUser, out kolom) == false || !isColumnInRangeOfBoard(char.Parse(inputUser), aantalKolommenBoard))
            {
                Console.WriteLine("Ongeldige kolom");
                inputUser = Console.ReadLine().ToUpper();
            }

            return kolom;
        }

        public static bool isColumnInRangeOfBoard(char kolom, int AantalKolommen)
        {
            // ===== START STUDENT CODE =====
            // TODO:
            // Return true als kolom tussen 'A' en de laatste kolomletter van het bord ligt.
            // Voorbeeld bij 10 kolommen: A..J
            // ===== END STUDENT CODE =====

            return false;
        }

        public static int askRowToUser(int aantalRijenOnBoard)
        {
            int rij;
            Console.WriteLine("Welke rij ?");
            string inputUser = Console.ReadLine();

            while (int.TryParse(inputUser, out rij) == false || !isRowInRangeOfBoard(int.Parse(inputUser), aantalRijenOnBoard))
            {
                Console.WriteLine("Ongeldige rij");
                inputUser = Console.ReadLine();
            }

            return rij;
        }

        public static bool isRowInRangeOfBoard(int rij, int AantalRijen)
        {
            // ===== START STUDENT CODE =====
            // TODO:
            // Return true als rij tussen 1 en AantalRijen ligt.
            // ===== END STUDENT CODE =====
            return false;
        }

        public static bool askPositionToUser()
        {
            bool plaatsHorizontaal = false;
            Console.WriteLine("Horizontaal plaatsen true/false");

            while (bool.TryParse(Console.ReadLine(), out plaatsHorizontaal) == false)
            {
                Console.WriteLine("Ongeldige positie (true/false)");
            }

            return plaatsHorizontaal;
        }
    }
}
