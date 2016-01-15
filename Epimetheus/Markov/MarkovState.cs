using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
   
    class MarkovState
    {
        public bool isTerminal { get; set; }
        public double value {get; set; }
        public double estimatedValue { get; set; }
        public double nextEstimatedValue { get; set; }
        public List<StochasticAction> actions { get; private set; }
        public StochasticAction policy { get; set; }
        public int index { get; set; }

        public MarkovState ()
        {
            this.actions = new List<StochasticAction>();
        }

        public MarkovState(int index, int value)
        {
            this.actions = new List<StochasticAction>();
            this.index = index;
            this.value = value;
        }

        internal void addAction(StochasticAction action)
        {
            actions.Add(action);
        }

        internal void update()
        {
            if (isTerminal)
            {
                this.estimatedValue = this.value;
            }
            else
            {
                this.estimatedValue = nextEstimatedValue;
            }
        }

        internal void calculatePolicy()
        {
            double bestActionValue = -1000000000;

            foreach (StochasticAction action in actions)
            {
                double actionValue = 0;

                foreach (ActionResult result in action.getPossibleResults())
                {
                    actionValue += result.probability * result.state.estimatedValue;
                }

                if (actionValue > bestActionValue)
                {
                    policy = action;
                    bestActionValue = actionValue;
                }
            }
        }

        internal void reset()
        {
            this.estimatedValue = value;
            this.nextEstimatedValue = value;
        }
    }
}
