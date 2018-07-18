using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Player
    {
        public char Name { get; set; }

        public Player(char name)
        {
            Name = name;
        }
        public static void GetInput(Player player)
        {
            Console.Write($"Player {player.Name} turn:");
            int field = Convert.ToInt32(Console.ReadLine());
            if (field < 1 && field > 9)
            {
                Console.WriteLine("Try again with a number withing the limits (1 to 9)");
                GetInput(player);
            }
            Play(player, field);
        }

        public static void Play(Player player, int field)
        {
            if (!GameEngine.SelectedPositions.Contains(field))
            {
                switch (field)
                {
                    case 7:
                        GameEngine.Board[0, 0] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(7);
                        break;
                    case 8:
                        GameEngine.Board[0, 1] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(8);
                        break;
                    case 9:
                        GameEngine.Board[0, 2] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(9);
                        break;
                    case 4:
                        GameEngine.Board[1, 0] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(4);
                        break;
                    case 5:
                        GameEngine.Board[1, 1] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(5);
                        break;
                    case 6:
                        GameEngine.Board[1, 2] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(6);
                        break;
                    case 1:
                        GameEngine.Board[2, 0] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(1);
                        break;
                    case 2:
                        GameEngine.Board[2, 1] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(2);
                        break;
                    case 3:
                        GameEngine.Board[2, 2] = player.Name == 'X' ? 'X' : 'O';
                        GameEngine.SelectedPositions.Add(3);
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

    }
}
