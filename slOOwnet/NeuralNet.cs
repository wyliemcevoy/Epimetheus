using System;
using System.Collections.Generic;
using System.Linq;

namespace Epimetheus
{
    class NeuralNet
    {
        private List<List<Node>> layers;
        public int inputSize { get; private set; }
        public int outputSize { get; private set; }
        
        /// <summary>
        /// Sigmoids store no internal information. So a single instance of the object can be shared across all nodes.
        /// </summary>
        private ActivationFunction sigmoid;
        /// <summary>
        ///Identity activation functions store no internal information. So a single instance of the object can be shared across all nodes.
        /// </summary>
        private ActivationFunction identity;

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
            sigmoid = new Sigmoid();
            identity = new Identity();

            // Initialize unconnected Nodes in each layer
            for(int layerIndex = 0; layerIndex < layerStructure.Count(); layerIndex++)
            {
                List<Node> currentLayer = new List<Node>();

                for(int i = 0; i<layerStructure[layerIndex]; i++)
                {
                    if (layerIndex == 0)
                    {
                        currentLayer.Add(new Node(identity));
                    } else
                    {
                        currentLayer.Add(new Node(sigmoid));
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
            foreach (Node node in layers[layers.Count()-1])
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

        public double[] predict(double[] input)
        {
            setInput(input);
            forwardPass();
            return Output;
        }

        public void backPropogate(double alpha, double[] actual)
        {
            // Output layer is calculated first
            for (int i= 0; i< layers[layers.Count() - 1].Count(); i++)
            {
                Node node = layers[layers.Count() - 1][i];
                node.backPropagate(alpha, actual[i]);
            }

            // Propogate backwards across all hidden layers
            for(int i = layers.Count()-2; i>0; i--)
            {
                int index = 0;
                foreach (Node node in layers[i])
                {
                    node.backPropagate(alpha);
                    index++;
                }
            }

            

        }

        public void update()
        {
            // Non batch processing so update weights after propogation of error

            foreach (List<Node> layer in layers)
            {
                foreach (Node node in layer)
                {
                    node.update();
                }
            }
        }


        static internal double setOutputToInput(double input)
        {
            return input;
        }
        
        static internal double returnOne(double input)
        {
            return 1;
        }


        public override String ToString()
        {
            string build = "[[ ";

            foreach (List<Node> layer in layers)
            {
                build += "( ";
                foreach(Node node in layer)
                {
                    build += node + " ";
                }
                build += ")";
            }

            build += " ]]";
            return build;
        }

    }
}
