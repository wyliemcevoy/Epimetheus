using Epimetheus.QNet;
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
            ReplayMemory memory = new ReplayMemory();

            while(!game.isCompleted)
            {
                Console.Clear();
                Console.WriteLine(game);
                memory.Add(game.toQNetState());
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

            foreach(QNetState state in memory)
            {
                Console.Clear();
                Console.Write(state);
                System.Threading.Thread.Sleep(100);
            }
        }


    }
}
