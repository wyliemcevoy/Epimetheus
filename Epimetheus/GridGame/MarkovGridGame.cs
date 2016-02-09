using Epimetheus.QNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.GridGame
{
    public class MarkovGridGame
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int reward { get; private set; }
        public bool isCompleted { get; set; }
        public enum Action { up, down, left, right }
        public int numberOfActions { get; private set; }


        private int[,] state;
        private Random rand;
        private Agent agent;
        private List<Obstacle> obstacles;




        public MarkovGridGame(int width, int height, int seed)
        {
            this.width = width;
            this.height = height;
            this.numberOfActions = 4;
            this.isCompleted = false;
            this.state = new int[height, width];
            this.obstacles = new List<Obstacle>();
            this.rand = new Random(seed);
        }

        public void acceptAction(int input)
        {
            // int to Action Mapping
            switch (input)
            {
                case 0:
                    update(Action.down);
                    break;
                case 1:
                    update(Action.up);
                    break;
                case 2:
                    update(Action.left);
                    break;
                case 3:
                    update(Action.right);
                    break;
            }
        }

        public void update(Action action)
        {
            switch (action)
            {
                case Action.down:
                    agent.y++;
                    break;
                case Action.up:
                    agent.y--;
                    break;
                case Action.left:
                    agent.x--;
                    break;
                case Action.right:
                    agent.x++;
                    break;
            }
            sanatizePlayer();
            checkTerminal();
        }

        private void checkTerminal()
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if(obstacle.isTerminal && obstacle.inConision(agent))
                {
                    this.isCompleted = true;
                }
            }
        }

        private void sanatizePlayer()
        {
            agent.x = Math.Max(0, Math.Min(agent.x, width-1));
            agent.y = Math.Max(0, Math.Min(agent.y, height-1));
        }


        public void buildRandomGame()
        {
            obstacles.Add(new Obstacle(rand.Next(0, width-1), rand.Next(0, height-1),true, 100));
            agent = new Agent(rand.Next(0, width - 1), rand.Next(0, height - 1));
        }

        public int[,] toOutput()
        {
            int[,] output = new int[height, width];


            output[agent.y, agent.x] = 10;
            foreach (Obstacle obstacle in obstacles)
            {
                output[obstacle.y, obstacle.x] = obstacle.value;
            }

            return output;
        }

        public QNetState toQNetState()
        {
            return new QNetState(squash(toOutput()), 0, isCompleted);
        }

        private int[] squash(int[,] array)
        {
            int[] tmp = new int[array.GetLength(0) * array.GetLength(1)];
            Buffer.BlockCopy(array, 0, tmp, 0, tmp.Length * sizeof(int));
            return tmp;
        }

        public void reset()
        {
            // TODO : Implement ...
            buildRandomGame();
        }


        public override string ToString()
        {
            string build = "";
            int[,] output = this.toOutput();
            
            for(int y=0; y<height;y++)
            {
                for(int x=0; x<height; x++)
                {
                    switch (output[y, x])
                    {
                        case 0:
                            build += " ";
                            break;
                        case 100:
                            build += "X";
                            break;
                        case 10:
                            build += "@";
                            break;
                        default:
                            build += " ";
                            break;
                    }
                }
                build += "\n";
            }
            build += "agent : (" + agent.x + "," + agent.y + ")";


            return build;
        }

        class GameObject {
            internal int x { get; set; }
            internal int y { get; set; }
            public GameObject(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public bool inConision(GameObject other)
            {
                return x == other.x && y == other.y;
            }
        }

        class Obstacle : GameObject
        {
            internal bool isTerminal { get; set; }
            internal int value { get; set; }
            public Obstacle(int x, int y, bool isTerminal, int value) :base(x,y)
            {
                this.value = value;
                this.isTerminal = isTerminal;
            }
        }

        class Agent : GameObject
        {
            public Agent(int x, int y) : base(x, y)
            {

            }
        }
    }
}
