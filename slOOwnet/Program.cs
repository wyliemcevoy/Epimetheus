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
            //DataSetParser dsp = new DataSetParser();
            //LearningDataSet data = dsp.openFilePicker();

            Random rand = new Random();
            LearningDataSet dataSet = new LearningDataSet(2, 1);

            for (int i = 0; i < 100; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (rand.NextDouble() > .5)
                {
                    //x *= -1;
                }

                if (rand.NextDouble() > .5)
                {
                    //y *= -1;
                }
                dataSet.add(new TestInstance(new double[] { x, y }, new double[] { 1 / (1 + Math.Exp(-1 * (x * .5 + y * .25))) }));
            }
            NeuralNet net = new NeuralNet(new int[] {2,1});
            Console.WriteLine(net.NodeCount());
            Console.WriteLine(net.EdgeCount());


            BackPropogationRunner bp = new BackPropogationRunner(dataSet, net);
            bp.run(.5, 100);

            Console.ReadLine();
        }
    }
}
