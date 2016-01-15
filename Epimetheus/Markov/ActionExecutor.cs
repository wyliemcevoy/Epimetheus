using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    class ActionExecutor
    {
        private Random rand;
        public ActionExecutor(int seed)
        {
            this.rand = new Random(seed);
        }

        public MarkovState getResult(StochasticAction action)
        {
            double value = rand.NextDouble();
            double current = 0.0;
            ActionResult result = null;
            int i = 0;
            List<ActionResult> results = action.getPossibleResults();
            while( i<results.Count() && current <value)
            {
                result = results[i];
                current += result.probability;
                i++;
            }

            return result.state;
        }
    }

}
