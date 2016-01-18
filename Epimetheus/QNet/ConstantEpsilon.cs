using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    class ConstantEpsilon : Epsilon
    {
        private double epsilon;

        public ConstantEpsilon(double epsilon)
        {
            this.epsilon = epsilon;
        }

        public double getE()
        {
            return epsilon;
        }

        public void update(int count)
        {
            // Do nothing
        }
    }
}
