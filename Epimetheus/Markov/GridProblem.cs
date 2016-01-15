using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    class GridProblem : MarkovProblem
    {
        private MarkovState[,] grid;
        private List<MarkovState> states;
        private int width = 10;
        private int height = 12;

        public GridProblem(int i)
        {

            this.width = i;
            this.height = i;

            intializeGrid();
        }

        public GridProblem()
        {
            intializeGrid();
        }

        private void intializeGrid()
        {
            this.states = new List<MarkovState>();
            this.grid = new MarkovState[height,width];
            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y,x] = new MarkovState(index, 0);
                    grid[y,x].value = -1;
                    states.Add(grid[y,x]);
                    index++;
                }
            }

            grid[height / 2 - 1,width / 2 - 1].isTerminal = true;
            grid[height / 2 - 1,width / 2 - 1].value = -100;
            grid[height - 1,width - 1].isTerminal = true;
            grid[height - 1,width - 1].value = 100;

            intializeActions();
        }

        private void intializeActions()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    createActions(x, y);
                }
            }
        }

        private void createActions(int x, int y)
        {
            MarkovState state = get(x, y);
            state.addAction(createAction(Direction.up, x, y));
            state.addAction(createAction(Direction.down, x, y));
            state.addAction(createAction(Direction.left, x, y));
            state.addAction(createAction(Direction.right, x, y));
        }

        
    public MarkovState getStartState()
        {
            return grid[0,0];
        }

        
    public List<MarkovState> getStates()
        {
            return states;
        }

        private StochasticAction createAction(Direction direction, int x, int y)
        {
            StochasticAction action = null;

            ActionResult up = new ActionResult(get(x, y - 1));
            ActionResult down = new ActionResult(get(x, y + 1));
            ActionResult left = new ActionResult(get(x - 1, y));
            ActionResult right = new ActionResult(get(x + 1, y));

            switch (direction)
            {
                case Direction.down:
                    action = new GridAction("v");

                    // go down
                    down.probability = .8;
                    action.addPossible(down);

                    // go left
                    left.probability = .1;
                    action.addPossible(left);

                    // go right
                    right.probability = .1;
                    action.addPossible(right);

                    break;
                case Direction.left:

                    action = new GridAction("<");

                    // go left
                    left.probability = .8;
                    action.addPossible(left);

                    // go up
                    up.probability = .1;
                    action.addPossible(up);

                    // go down
                    down.probability = .1;
                    action.addPossible(down);

                    break;
                case Direction.right:

                    action = new GridAction(">");
                    // go right
                    right.probability = .8;
                    action.addPossible(right);

                    // go up
                    up.probability = .1;
                    action.addPossible(up);

                    // go down
                    down.probability = .1;
                    action.addPossible(down);

                    break;
                case Direction.up:

                    action = new GridAction("^");
                    // go down
                    up.probability = .8;
                    action.addPossible(up);

                    // go left
                    left.probability = .1;
                    action.addPossible(left);

                    // go right
                    right.probability = .1;
                    action.addPossible(right);

                    break;
                default:
                    break;
            }

            return action;
        }

        private MarkovState get(int x, int y)
        {
            return grid[sanatizeY(y),sanatizeX(x)];
        }

        private int sanatizeX(int x)
        {
            return Math.Max(Math.Min(x, width - 1), 0);
        }

        private int sanatizeY(int y)
        {
            return Math.Max(Math.Min(y, height - 1), 0);

        }

        
        public override String ToString()
        {
            String build = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    String num = "" + ((int)get(x, y).estimatedValue);

                    String buf = " ";
                    int size = 4 - num.Count();

                    for (int i = 0; i < size; i++)
                    {
                        buf += " ";
                    }

                    build += buf + num + " ";

                }
                build += "\n";
            }
            return build;
        }

        public void update() {
            foreach (MarkovState state in states)
            {
                state.update();
            }
        }

        public void calculatePolicy()
        {
            foreach (MarkovState state in states)
            {
                state.calculatePolicy();
            }
        }

        public String getPolicyAsString()
        {

            String build = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    String num = "" + ((int)get(x, y).estimatedValue);

                    String buf = " ";
                    int size = 4 - num.Count();

                    for (int i = 0; i < size; i++)
                    {
                        buf += " ";
                    }

                    build += buf + num + " ";
                    MarkovState state = get(x, y);
                    state.calculatePolicy();
                    if (state.policy != null)
                    {

                        build += state.policy.getName() + " ";

                    }
                }
                build += "\n";
            }
            return build;
        }

        public String getOptimalPath()
        {
            Boolean[,] path = new Boolean[height,width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    path[y,x] = false;
                }

            }

            MarkovState currentState = getStartState();

            while (!currentState.isTerminal)
            {

            }

            String build = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    String buf = " ";
                    if (path[y,x])
                    {
                        build += "  O";
                    }
                    else
                    {

                    }

                    build += buf + ((int)get(x, y).estimatedValue) + " ";
                }
                build += "\n";
            }
            return build;
        }

        public MarkovState getState(int i)
        {
            return states[i];
        }

        
        public void reset()
        {
            foreach (MarkovState state in states)
            {
                state.reset();
            }

        }
    }
}
