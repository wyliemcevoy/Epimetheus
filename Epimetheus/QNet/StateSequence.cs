using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    class StateSequence
    {
        private List<QNetState> states;

        public StateSequence()
        {
            states = new List<QNetState>();
        }

        public void Add(QNetState state)
        {
            states.Add(state);
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
