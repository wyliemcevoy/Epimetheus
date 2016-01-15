using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    class Sigmoid : ActivationFunction
    {
        public double calculateGradient(Node node)
        {
            return node.netOut * (1 - node.netOut);
        }

        public double calculateOuptut(Node node)
        {
            return 1 / (1 + Math.Exp(-node.netIn));
        }
    }
}
