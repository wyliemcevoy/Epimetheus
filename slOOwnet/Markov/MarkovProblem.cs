using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet.Markov
{
    interface MarkovProblem
    {
        MarkovState getStartState();

        List<MarkovState> getStates();

        void update();

        MarkovState getState(int i);

        String getPolicyAsString();

        void calculatePolicy();

        void reset();
    }
}
