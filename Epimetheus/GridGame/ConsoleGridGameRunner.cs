using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.GridGame
{
    class ConsoleGridGameRunner
    {
        private GridGame game;
        
        
        public ConsoleGridGameRunner()
        {
            game = new GridGame(10,10,0);
            game.buildRandomGame();

            while(!game.isCompleted)
            {
                Console.WriteLine(game);

                ConsoleKeyInfo ki = Console.ReadKey();

                switch (ki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("left");

                        break;

                    case ConsoleKey.RightArrow:
                        Console.WriteLine("right");

                        break;
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("up");

                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("down");

                        break;
                }

            }
        }


    }
}
