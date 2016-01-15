using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    interface ActivationFunction
    {
        double calculateOuptut(Node node);
        double calculateGradient(Node node);
    }
}
