﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    interface LearningRate
    {
        double getAlpha(Node node, Edge edge);
    }
}
