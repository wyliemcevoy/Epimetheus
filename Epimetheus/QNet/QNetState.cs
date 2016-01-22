using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    public class QNetState
    {
        public bool isTerminal { get; set; }
        public int[] input {get; set;}
        public double reward { get; set; }
        public int chosenAction { get; set; }

        public QNetState(int[] input, double reward, bool isTerminal)
        {
            this.input = input;
            this.reward = reward;
            this.isTerminal = isTerminal;
        }

        public override string ToString()
        {
            String build = "";
            for(int i=0; i<100; i++)
            {
                switch (input[i])
                {
                    case 0:
                        build += " ";
                        break;
                    case 100:
                        build += "X";
                        break;
                    case 10:
                        build += "@";
                        break;
                    default:
                        build += " ";
                        break;
                }

                if ((i+1)%10 == 0)
                {
                    build += "\n";
                }

            }
            build += "action : " + chosenAction + " reward : " + reward + "\n";

            return build;
        }

    }
}
