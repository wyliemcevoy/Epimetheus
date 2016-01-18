using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    interface Epsilon
    {
        double getE();
        void update(int count);
    }
}
