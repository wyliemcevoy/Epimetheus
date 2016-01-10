using System;
using System.Collections.Generic;
using System.Linq;

namespace slOOwnet
{
    class NeuralNet
    {
        private List<List<Node>> layers;
        public int inputSize { get; private set; }
        public int outputSize { get; private set; }

        public double[] Output
        {
            get { return getOutput(); }
            private set{ Output = value; }
        }

        public NeuralNet(int[] layerStructure)
        {
            layers = new List<List<Node>>();
            inputSize = layerStructure.First();
            outputSize = layerStructure.Last();

            // Initialize unconnected Nodes in each layer
            for(int layerIndex = 0; layerIndex < layerStructure.Count(); layerIndex++)
            {
                List<Node> currentLayer = new List<Node>();

                for(int i = 0; i<layerStructure[layerIndex]; i++)
                {
                    if (layerIndex == 0)
                    {
                        currentLayer.Add(new Node(setOutputToInput,returnOne));
                    } else
                    {
                        currentLayer.Add(new Node(sigmoid, sigmoidGradient));
                    }
                }

                layers.Add(currentLayer);   
            }

            // Initialize Edges between Layers
            for(int i=0; i<layers.Count-1; i++)
            {
                connectLayer(layers[i], layers[i + 1]);
            }

        }

        private double[] getOutput()
        {
            double[] output = new double[this.outputSize];

            int i = 0;
            foreach (Node node in layers[-1])
            {
                output[i] = node.netOut;
                i++;
            }

            return output;
        }

        private void connectLayer(List<Node> tails, List<Node> heads)
        {
            Random rand = new Random();
            foreach (Node tail in tails)
            {
                foreach (Node head in heads)
                {
                    Edge edge = new Edge(tail, head);
                    edge.weight = rand.NextDouble();
                    tail.addOutEdge(edge);
                    head.adInEdge(edge);
                }
            }
        }
        

        public int NodeCount()
        {
            int count = 0;
            foreach(List<Node> layer in layers)
            {
                count += layer.Count;
            }
            return count;
        }

        public int EdgeCount()
        {
            int count = 0;
            foreach (List<Node> layer in layers)
            {
                foreach(Node node in layer)
                {
                    count += node.getOutEdgeCount();
                }
            }
            return count;
        }


        public void setInput(double[] input)
        {
            if(input.Count() == inputSize)
            {
                List <Node> inputLayer = layers[0];

                for(int i=0; i<inputSize; i++)
                {
                    inputLayer[i].netIn = input[i];
                }

            } else
            {
                // TODO : Handle bad input
            }
        }

        public void forwardPass()
        {
            foreach (List<Node> layer in layers)
            {
                foreach (Node node in layer)
                {
                    node.calculate();
                }
            }
        }

        public void backPropogate(double sumOfSquaredError)
        {
            for(int i = layers.Count(); i>=0; i--)
            {
                foreach (Node node in layers[i])
                {

                }
            }

        }


        static internal double setOutputToInput(double input)
        {
            return input;
        }

        static internal double sigmoid(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        static internal double returnOne(double input)
        {
            return 1;
        }

        static internal double sigmoidGradient(double netOut)
        {
            return netOut*(1 - netOut);
        }

    }
}
