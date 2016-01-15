using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus
{
    public class LearningDataSet
    {
        public List<TestInstance> Instances { get; private set; }
        public int InputCount { get; private set; }
        public int OutputCount { get; private set; }

        public LearningDataSet(int InputCount, int OutputCount)
        {
            this.InputCount = InputCount;
            this.OutputCount = OutputCount;
            this.Instances = new List<TestInstance>();
        }

        public void add(IEnumerable<double> Input, IEnumerable<double> Output)
        {
            if(Input.Count() == InputCount && Output.Count() == OutputCount)
            {
                add(new TestInstance(Input, Output));
            } else
            {
                // TODO: Handle bad input
            }
        }

        public void add(TestInstance testInstance)
        {
            Instances.Add(testInstance);
        }
    }
}