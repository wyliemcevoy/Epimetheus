﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epimetheus.Markov;
using Epimetheus.GridGame;
using Epimetheus.QNet;

namespace Epimetheus
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ConsoleGridGameRunner gg = new ConsoleGridGameRunner();
            QNetTest();
            Console.ReadLine();
        }

        static void QNetTest()
        {
            MarkovGridGame game = new MarkovGridGame(10, 10, 0);
            game.buildRandomGame();
            QNetAgent agent = new QNetAgent();
            agent.runTest(game, 0);

        }



        static void runMarkovProblemSovler()
        {
            MarkovProblemSolver qlearner = new QLearningAgent(10000, 10000, 1);
            qlearner.accept(new GridProblem());
            qlearner.solve();
        }

        static void netTest()
        {

            Random rand = new Random();
            LearningDataSet dataSet = new LearningDataSet(2, 1);

            for (int i = 0; i < 1000; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (rand.NextDouble() > .5)
                {
                    x *= -1;
                }

                if (rand.NextDouble() > .5)
                {
                    y *= -1;
                }

                double w = 1 / (1 + Math.Exp(-1 * (x * 1 + .25 * y)));
                double z = 1 / (1 + Math.Exp(-1 * (x * .5 + 0 * y)));

                double a = 1 / (1 + Math.Exp(-1 * (w - z)));
                double b = 1 / (1 + Math.Exp(-1 * (w + z)));
                double c = 1 / (1 + Math.Exp(-1 * (w)));
                double d = 1 / (1 + Math.Exp(-1 * (z)));


                dataSet.add(new TestInstance(new double[] { x, y }, new double[] { a, b, c, d }));
            }

            Console.WriteLine("Dataset loaded.");
            NeuralNet net = new NeuralNet(new int[] { 2, 2, 4 });
            Console.WriteLine(net.NodeCount());
            Console.WriteLine(net.EdgeCount());


            BackPropagationRunner bp = new BackPropagationRunner(dataSet, net);
            bp.run(.5, 10000);

        }
    }
}
