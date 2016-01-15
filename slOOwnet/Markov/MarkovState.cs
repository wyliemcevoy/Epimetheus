using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet.Markov
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
            this.index = index;
            this.value = value;
        }

        internal void addAction(StochasticAction action)
        {
            actions.Add(action);
        }

        internal void update()
        {
            throw new NotImplementedException();
        }

        internal void calculatePolicy()
        {
            throw new NotImplementedException();
        }

        internal void reset()
        {
            throw new NotImplementedException();
        }
    }
}
