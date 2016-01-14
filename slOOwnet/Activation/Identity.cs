using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    class Identity : ActivationFunction
    {
        public double calculateOuptut(Node node)
        {
            return node.netIn;
        }
        public double calculateGradient(Node node)
        {
            return 1;
        }
    }
}
