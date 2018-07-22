using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Player xPlayer = new Player('X');
            Player oPlayer = new Player('O');
            GameEngine.StartGame(xPlayer, oPlayer);
            Console.ReadKey();
        }
    }
}
