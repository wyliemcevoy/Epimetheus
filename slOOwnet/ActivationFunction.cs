using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    interface ActivationFunction
    {
        double calculate(double input);
        double calculateGradient(double output);
    }
}
