﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet.Markov
{
    interface MarkovProblemSolver
    {
        void accept(MarkovProblem problem);

        void solve();

        int getNumberOfItterations();
    }
}
