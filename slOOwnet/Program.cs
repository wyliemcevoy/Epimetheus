using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DataSetParser dsp = new DataSetParser();
            dsp.openFilePicker();


            Random rand = new Random();

            for(int i=0; i< 1000; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (rand.NextDouble() >.5)
                {
                    x *= -1;
                }

                if(rand.NextDouble() > .5)
                {
                    y *= -1;
                }

                Console.WriteLine(x+ "," + y + ":" +(x*.5 + y*.25));
            }


            NeuralNet net = new NeuralNet(new int[] {10,10,10});
            Console.WriteLine(net.NodeCount());
            Console.WriteLine(net.EdgeCount());
            Console.ReadLine();
        }
    }
}
