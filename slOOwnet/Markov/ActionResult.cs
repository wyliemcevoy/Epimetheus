using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet.Markov
{
    class ActionResult
    {
        private MarkovState markovState;

        public ActionResult(MarkovState markovState)
        {
            this.markovState = markovState;
        }

        public double probability { get; set; }
        public MarkovState state { get; set; }
    }
}
