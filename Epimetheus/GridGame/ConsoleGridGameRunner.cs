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
                Console.Clear();
                Console.WriteLine(game);

                ConsoleKeyInfo ki = Console.ReadKey();

                switch (ki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.update(GridGame.Action.left);
                        break;

                    case ConsoleKey.RightArrow:
                        game.update(GridGame.Action.right);
                        break;
                    case ConsoleKey.UpArrow:
                        game.update(GridGame.Action.up);
                        break;
                    case ConsoleKey.DownArrow:
                        game.update(GridGame.Action.down);
                        break;
                }


            }
        }


    }
}
