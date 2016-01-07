using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    class Perceptron : Node
    {

        public override void calculate()
        {
            updateNetIn();
            netOut =  1 / (1 + Math.Exp(-netIn));
        }
    }
}
