﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    class QNetState
    {
        public bool isTerminal { get; set; }
        public int[] input {get; set;}
        public double reward { get; set; }
        public double[] output { get; set; }

        public QNetState(int[] input, double reward, bool isTerminal)
        {
            this.input = input;
            this.reward = reward;
            this.isTerminal = isTerminal;
        }
    }
}
