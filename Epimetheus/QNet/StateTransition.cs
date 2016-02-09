using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet.QNet
{
    class StateTransition
    {
        public double[] start { get; set; }
        public double[] finish { get; set; }
        public int action { get; set; }
        public int reward { get; set; }

    }
}
