using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    interface StochasticAction
    {
        List<ActionResult> getPossibleResults();
        void addPossible(ActionResult actionResult);
        String getName();
    }
}
