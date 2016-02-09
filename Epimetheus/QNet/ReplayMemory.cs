using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    class ReplayMemory
    {
        private List<QNetState> states;

        public ReplayMemory()
        {
            states = new List<QNetState>();
        }

        public void Add(QNetState state)
        {
            states.Add(state);
        }

        public double[] getPhi()
        {
            double[] phi = new double[40];
            if(states.Count() > 3 )
            {
                int j = 0;
                for (int i = states.Count() - 4; i < states.Count(); i++)
                {
                    foreach (double d in states[i].input)
                    {
                        phi[j] = d;
                        j++;
                    }
                }
            }
            return phi;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            foreach (QNetState state in states)
            {
                yield return state;
            }
        }
    }
}
