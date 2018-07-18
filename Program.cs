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
            Player X = new Player('X');
            Player O = new Player('O');
            do
            {
                Player.GetInput(X);
                if (GameEngine.GameOver())
                    break;
                if (GameEngine.Draw())
                    break;
                GameEngine.VisualizeBoard();
                Player.GetInput(O);
                GameEngine.VisualizeBoard();
            } while (!GameEngine.GameOver());
            GameEngine.VisualizeBoard();
            Console.ReadKey();
        }
    }
}
