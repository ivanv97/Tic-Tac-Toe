using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class GameEngine
    {
        public static char[,] Board { get; set; } = new char[3, 3];
        public static List<int> SelectedPositions { get; set; } = new List<int>();

        public static void VisualizeBoard()
        {
            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    char currentElement = Board[rows, cols] != '\0' ? Board[rows, cols] : ' ';
                    Console.Write(currentElement.ToString());
                    if (cols < 2)
                    {
                        Console.Write("  |");
                    }
                }
                Console.WriteLine();
                if (rows < 2)
                {
                    Console.WriteLine("---+---+---");
                }
            }
        }

        public static bool GameOver()
        {
            for (int rows = 0, cols = 0, over; rows < 3; rows++)
            {
                over = 1;
                for (; cols < 2; cols++)
                {
                    if (Board[rows, cols] == Board[rows, cols + 1] && Board[rows, cols] != 0)
                    {
                        over++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (over == 3)
                {
                    string message = Board[rows, cols] == 'X' ? "Player one (X) wins!" : "Player two (O) wins!";
                    Console.WriteLine(message);
                    return true;
                }
            }


            for (int cols = 0, rows = 0, over; cols < 3; cols++)
            {
                over = 1;
                for (; rows < 2; rows++)
                {
                    if (Board[rows, cols] == Board[rows + 1, cols] && Board[rows, cols] != 0)
                    {
                        over++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (over == 3)
                {
                    string message = Board[rows, cols] == 'X' ? "Player one (X) wins!" : "Player two (O) wins!";
                    Console.WriteLine(message);
                    return true;
                }
            }

            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[1, 1] != 0)
            {
                string message = Board[1, 1] == 'X' ? "Player one (X) wins!" : "Player two (O) wins!";
                Console.WriteLine(message);
                return true;
            }
            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[1, 1] != 0)
            {
                string message = Board[1, 1] == 'X' ? "Player one (X) wins!" : "Player two (O) wins!";
                Console.WriteLine(message);
                return true;
            }

            return false;
        }

        public static bool Draw()
        {
            if (SelectedPositions.Count == 9)
            {
                Console.WriteLine("Draw");
                return true;
            }
            return false;
        }
    }
}
