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

        public NeuralNet(int[] layerStructure)
        {
            layers = new List<List<Node>>();
            inputSize = layerStructure.First();
            outputSize = layerStructure.Last();

            // Initialize unconnected Nodes in each layer
            for(int layerIndex = 0; layerIndex < layerStructure.Count(); layerIndex++)
            {
                List<Node> currentLayer = new List<Node>();
                bool inputOrOutputLayer = layerIndex == 0 || layerIndex == layerStructure.Count() - 1;

                for(int i = 0; i<layerStructure[layerIndex]; i++)
                {
                    if (inputOrOutputLayer)
                    {
                        currentLayer.Add(new Node());
                    } else
                    {
                        currentLayer.Add(new Perceptron());
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

    }
}
