using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    class ActionResult
    {
        public ActionResult(MarkovState markovState)
        {
            this.state = markovState;
        }

        public double probability { get; set; }
        public MarkovState state { get; set; }
    }
}
