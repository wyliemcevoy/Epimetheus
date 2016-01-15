using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    public class TestInstance
    {
        public readonly double[] Input;
        public readonly double[] Output;

        public TestInstance(IEnumerable<double> input, IEnumerable<double> output)
        {
            Input = new double[input.Count()];
            Output = new double[output.Count()];

            int i = 0;
            foreach (double d in input){
                Input[i] = d;
                i++;
            }
            i = 0;
            foreach(double d in output)
            {
                Output[i] = d;
                i++;
            }
        }
    }
}
