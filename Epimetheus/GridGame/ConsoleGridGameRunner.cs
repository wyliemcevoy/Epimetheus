using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.GridGame
{
    class ConsoleGridGameRunner
    {
        private MarkovGridGame game;
        
        
        public ConsoleGridGameRunner()
        {
            game = new MarkovGridGame(10,10,0);
            game.buildRandomGame();

            while(!game.isCompleted)
            {
                Console.Clear();
                Console.WriteLine(game);

                ConsoleKeyInfo ki = Console.ReadKey();

                switch (ki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.update(MarkovGridGame.Action.left);
                        break;

                    case ConsoleKey.RightArrow:
                        game.update(MarkovGridGame.Action.right);
                        break;
                    case ConsoleKey.UpArrow:
                        game.update(MarkovGridGame.Action.up);
                        break;
                    case ConsoleKey.DownArrow:
                        game.update(MarkovGridGame.Action.down);
                        break;
                }


            }
        }


    }
}
