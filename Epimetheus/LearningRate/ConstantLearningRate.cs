using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    class ConstantLearningRate : LearningRate
    {
        private double constant;

        public ConstantLearningRate(double constant)
        {
            this.constant = constant;
        }

        public double getAlpha(Node node, Edge edge)
        {
            return constant;
        }
    }
}
