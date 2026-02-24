namespace Examen_ADB_635_Pasen
{
    internal class Program
    {

        static List<Boat> boats = new List<Boat>();
        // boardWherePlayerShoots = bord dat de speler ziet en waarop de speler schiet
        // boardWhereComputerShoots = bord dat de computer gebruikt en waarop de computer schiet

        static Board boardWherePlayerShoots;
        static Board boardWhereComputerShoots;
        static Random objRandom = new Random();
        static void Main(string[] args)
        {

            // ===== START STUDENT  =====
            // LOS ALLE ERRORS OP VOOR JE BEGINT MET DE OPDRACHT
            // WIJZIG GEEN SIGNATUUR VAN DE CODE DIE JE KRIJGT
            // VOEG ENKEL CODE TOE IN DE VOORZIENE BLOKKEN
            // ALLES DIE BUITEN DE START/END CODE STAAT WORDT NIET BEOORDEELD
            // Tip:
            // Als boten door elkaar staan of buiten bord gaan: 
            // kijk eerst naar canBoatPlacedOnBoard + areCellsAreFreeForPlacingBoat

            // ===== END STUDENT =====

            defineAllBoats();
            designBoards();


            boardWherePlayerShoots.placeBoatsOnBoardByComputer(boats);
            boardWhereComputerShoots.placeBoatsOnBoard(boats);


            Console.WriteLine("Klaar om te spelen. Druk op een toets");
            Console.ReadLine();

            boardWherePlayerShoots.HideBoats = true;

            while (!boardWherePlayerShoots.allBoatsSunk() && !boardWhereComputerShoots.allBoatsSunk())
            {
                boardWherePlayerShoots.tekenBoard();
                Console.WriteLine("Geef de coördinaten van je doelwit ");
                char checkKol = helper.askColumnToUser(boardWherePlayerShoots.AantalKolommen);
                int checkRij = helper.askRowToUser(boardWherePlayerShoots.AantalRijen);

                boardWherePlayerShoots.FireOnTarget(checkKol, checkRij);

                Console.WriteLine("Time to try the computer ");

                if (!boardWherePlayerShoots.allBoatsSunk())
                {
                    char column = (char)objRandom.Next('A', 'A' + boardWhereComputerShoots.AantalKolommen);
                    int row = objRandom.Next(1, boardWhereComputerShoots.AantalRijen + 1);
                    boardWhereComputerShoots.FireOnTarget(column, row);
                }
            }

            Player winner;
            Player loser;
            winner = boardWhereComputerShoots.Player;
            loser = boardWherePlayerShoots.Player;

            if (boardWherePlayerShoots.allBoatsSunk())
            {
                winner = boardWherePlayerShoots.Player;
                loser = boardWhereComputerShoots.Player;
            }

            Console.WriteLine($"{winner.Naam} {winner.Familienaam} is gewonnen met {winner.BoardAttempts} pogingen om het spel uit te spelen");
            Console.WriteLine($"{loser.Naam} {loser.Familienaam} is verloren met {loser.BoardAttempts} pogingen");

        }


        static void defineAllBoats()
        {

            // ===== START STUDENT CODE =====
            // Voeg de verschillende boten toe aan de lijst volgens het examen.
            // Vliegdekmoederschip(5)
            // Slagschip(4)
            // Kruiser(3)
            // Onderzeeër(3)
            // Mijnenveger(2)
            //
            // 
            // ===== END STUDENT CODE =====

        }

        static void designBoards()
        {
            boardWherePlayerShoots = new Board(10, 10);
            boardWherePlayerShoots.HideBoats = false;
            boardWhereComputerShoots = new Board(10, 10);
            boardWhereComputerShoots.HideBoats = false;
        }





    }
}

