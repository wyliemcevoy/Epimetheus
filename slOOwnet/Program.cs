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
            LearningDataSet data = dsp.openFilePicker();


            NeuralNet net = new NeuralNet(new int[] {10,10,10});
            Console.WriteLine(net.NodeCount());
            Console.WriteLine(net.EdgeCount());
            Console.ReadLine();
        }
    }
}
