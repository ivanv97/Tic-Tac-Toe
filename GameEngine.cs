using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class GameEngine
    {
        public static char[,] Board { get; private set; } = new char[3, 3];

        //A list of integers containing a number
        //corresponding to the already selected position
        public static List<int> SelectedPositions { get; private set; } = new List<int>();


        /* Method that visualizes the board in the console
         * using nested loops that iterate through every element */
        private static void VisualizeBoard()
        {
            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    char currentElement = Board[rows, cols] != '\0' ? Board[rows, cols] : ' ';
                    Console.Write(currentElement.ToString());
                    if (cols < 2)
                        Console.Write("  |");
                }
                Console.WriteLine();
                if (rows < 2)
                    Console.WriteLine("---+---+---");
            }
        }

        /*Method that returns true if either of the players won the game*/
        public static bool GameOverCheck(Player player)
        {
            char characterToCheck = player.Name;
            //Checking horizontaly
            for (int rows = 0, cols = 0, over; rows < 3; rows++)
            {
                if (Board[rows, cols] == characterToCheck)
                {
                    over = 1;
                    for (; cols < 2; cols++)
                    {
                        if (Board[rows, cols + 1] == characterToCheck)
                            over++;
                        else
                            break;
                    }
                    if (over == 3)
                    {
                        Console.WriteLine($"Player {characterToCheck} wins!");
                        return true;
                    }
                }
                else
                    continue;
            }

            //Checking vertically
            for (int cols = 0, rows = 0, over; cols < 3; cols++)
            {
                if (Board[rows, cols] == characterToCheck)
                {
                    over = 1;
                    for (; rows < 2; rows++)
                    {
                        if (Board[rows + 1, cols] == characterToCheck)
                            over++;
                        else
                            break;
                    }
                    if (over == 3)
                    {
                        Console.WriteLine($"Player {characterToCheck} wins!");
                        return true;
                    }
                }
                else
                    continue;
            }

            //Checking diagonally from top left to bottom right
            if (Board[0, 0] == characterToCheck)
            {
                if (Board[1, 1] == characterToCheck && Board[2, 2] == characterToCheck)
                {
                    Console.WriteLine($"Player {characterToCheck} wins!");
                    return true;
                }
            }

            //Checking diagonally from top right to bottom left
            if (Board[0, 2] == characterToCheck)
            {
                if (Board[1, 1] == characterToCheck && Board[2, 0] == characterToCheck)
                {
                    Console.WriteLine($"Player {characterToCheck} wins!");
                    return true;
                }
            }

            return false;
        }


        /*If all the positions become selected and no one
         * has won then it is a draw*/
        public static bool Draw()
        {
            if (SelectedPositions.Count == 9)
            {
                Console.WriteLine("Draw");
                return true;
            }
            return false;
        }


        /*Getting input from user - an integer from 1 to 9 */
        public static void GetInput(Player player)
        {
            Console.Write($"Player {player.Name} turn:");
            int field;
            if (!Int32.TryParse(Console.ReadLine(), out field) || (field < 1 || field > 9))
            {
                Console.WriteLine("Try again with a number withing the limits (1 to 9)");
                GetInput(player);
            }
            Play(player, field);
        }

        /*Each number as it is on the number pad on the standard keyboard
         * corresponds to the respective field of a 3 by 3 board */
        public static void Play(Player player, int field)
        {
            if (!SelectedPositions.Contains(field))
            {
                char fieldCharacter = player.Name;
                switch (field)
                {
                    case 7:
                        Board[0, 0] = fieldCharacter;
                        SelectedPositions.Add(7);
                        break;
                    case 8:
                        Board[0, 1] = fieldCharacter;
                        SelectedPositions.Add(8);
                        break;
                    case 9:
                        Board[0, 2] = fieldCharacter;
                        SelectedPositions.Add(9);
                        break;
                    case 4:
                        Board[1, 0] = fieldCharacter;
                        SelectedPositions.Add(4);
                        break;
                    case 5:
                        Board[1, 1] = fieldCharacter;
                        SelectedPositions.Add(5);
                        break;
                    case 6:
                        Board[1, 2] = fieldCharacter;
                        SelectedPositions.Add(6);
                        break;
                    case 1:
                        Board[2, 0] = fieldCharacter;
                        SelectedPositions.Add(1);
                        break;
                    case 2:
                        Board[2, 1] = fieldCharacter;
                        SelectedPositions.Add(2);
                        break;
                    case 3:
                        Board[2, 2] = fieldCharacter;
                        SelectedPositions.Add(3);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid position! Please select a different one!");
                GetInput(player);
            }
        }

        /* Starting a new game with two players */
        public static void StartGame(Player xPlayer, Player oPlayer)
        {
            VisualizeBoard();
            while (true)
            {
                GetInput(xPlayer);
                if (Draw())
                    break;
                if (GameOverCheck(xPlayer))
                    break;
                Console.WriteLine(Environment.NewLine);
                VisualizeBoard();
                GetInput(oPlayer);
                Console.WriteLine(Environment.NewLine);
                VisualizeBoard();
                if (GameOverCheck(oPlayer))
                    break;
            }
            VisualizeBoard();
        }
    }
}
