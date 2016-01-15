using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    class GridAction : StochasticAction 
    {
        public String name { get; private set; }
        private List<ActionResult> results;

        public GridAction(String name)
        {
            this.name = name;
            this.results = new List<ActionResult>();
        }

        public List<ActionResult> getPossibleResults()
        {
            return results;
        }

        public void addPossible(ActionResult actionResult)
        {
            results.Add(actionResult);
        }

        public string getName()
        {
            return name;
        }
    }
}
