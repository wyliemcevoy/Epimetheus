﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    class BackPropogationRunner
    {
        private LearningDataSet data;
        private NeuralNet neuralNet;
        private double errorThreshold;
        private int maxEpochs;
        /// <summary>Learning rate</summary>
        private double alpha;

        public BackPropogationRunner(LearningDataSet data)
        {
            this.data = data;
            neuralNet = new NeuralNet(new int[] { data.InputCount, 2, data.OutputCount});

        }

        public void run(double errorThreshold, int maxEpochs)
        {
            this.errorThreshold = errorThreshold;
            this.maxEpochs = maxEpochs;


            Console.WriteLine();
        }

        private void runInstance(TestInstance instance)
        {
            neuralNet.setInput(instance.Input);
            neuralNet.forwardPass();
            double[] predicted = neuralNet.Output;
            double[] actual = instance.Output;
            double[] error = calculateError(actual, predicted);

            double totalError = calculateSSE(actual, predicted);

        }

        /// <summary>
        /// Calculates a vector which is elementwise differnce between two vectors.
        /// </summary>
        /// <param name="actual">actual values</param>
        /// <param name="predicted">predicted values</param>
        /// <returns></returns>
        private double[] calculateError(double[] actual, double[] predicted)
        {
            double[] error = new double[actual.Count()];

            for (int i = 0; i < actual.Count(); i++)
            {
                error[i] = actual[i] - predicted[i];
            }

            return error;
        }

        /// <summary>
        /// Calculates the sum of squared error for two vectors.
        /// </summary>
        /// <param name="actual">actual values</param>
        /// <param name="predicted">predicted values</param>
        /// <returns></returns>
        private double calculateSSE(double[] actual, double[] predicted)
        {
            double totalError = 0;

            // Calculate sum of squared error 
            for (int i = 0; i<actual.Count(); i++)
            {
                totalError += .5 * Math.Pow((actual[i] - predicted[i]), 2);
            }
            return totalError;
        }
    }
}
