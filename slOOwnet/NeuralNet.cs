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
            foreach (int layerSize in layerStructure)
            {
                List<Node> currentLayer = new List<Node>();

                for(int i = 0; i<layerSize; i++)
                {
                    currentLayer.Add(new Node());
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
    }
}
