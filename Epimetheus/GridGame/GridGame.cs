using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.GridGame
{
    public class GridGame
    {
        public int width { get; private set; }
        public int height { get; private set; }
        private int[,] state;
        public enum Action { up, down, left, right }
        private Random rand;
        private Agent agent;
        private List<GameObject> gameObjects;
        public bool isCompleted { get; set; }



        public GridGame(int width, int height, int seed)
        {
            this.width = width;
            this.height = height;
            this.isCompleted = false;
            this.state = new int[width, height];
            this.gameObjects = new List<GameObject>();
            this.rand = new Random(seed);
        }

        public void acceptInput(double input)
        {
            Action action = Action.down;
            // int to Action Mapping


            // Update game based on Action



            update(action);
        }

        public void update(Action enumAction)
        {

        }


        public void buildRandomGame()
        {
            gameObjects.Add(new GameObject(rand.Next(0, width-1), rand.Next(0, height-1),true, 100));
            agent = new Agent(rand.Next(0, width - 1), rand.Next(0, height - 1));
        }

        public int[,] toOutput()
        {
            int[,] output = new int[width, height];


            output[agent.y, agent.x] = 10;
            foreach (GameObject gameObject in gameObjects)
            {
                output[gameObject.y, gameObject.x] = gameObject.value;
            }

            return output;
        }

        public override string ToString()
        {
            string build = "";
            int[,] output = this.toOutput();
            
            for(int x=0; x<width;x++)
            {
                for(int y=0; y<height; y++)
                {
                    build += output[y, x] + "\t";
                }
                build += "\n";
            }

            return build;
        }


        class GameObject
        {
            internal bool isTerminal { get; set; }
            internal int value { get; set; }
            internal int x { get; set; }
            internal int y { get; set; }
            public GameObject(int x, int y, bool isTerminal, int value)
            {
                this.x = x;
                this.y = y;
                this.value = value;
                this.isTerminal = isTerminal;
            }
        }

        class Agent
        {
            internal int x { get; set; }
            internal int y { get; set; }
            public Agent(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
