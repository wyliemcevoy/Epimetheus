using System;
using System.Collections.Generic;

namespace slOOwnet
{
    class Node
    {
        private List<Edge> outEdges;
        private List<Edge> inEdges;

        // TODO : move delegate definition to outside file? (research style conventions)
        public delegate double CalculateOutputDelegate(double input);
        public CalculateOutputDelegate calculateOutput { get; set; }
        public CalculateOutputDelegate calculateGradient { get; set; }
        public double dEdO { get; private set; }
        public double dOdN { get; private set; } // netOut * (1-netOut)

        public double netIn { get; set; }
        public double netOut { get; set; }

        public Node(CalculateOutputDelegate calculateOutput, CalculateOutputDelegate calculateGradient)
        {
            outEdges = new List<Edge>();
            inEdges = new List<Edge>();
            this.calculateOutput = calculateOutput;
            this.calculateGradient = calculateGradient;
        }

        public void addOutEdge(Edge edge)
        {
            outEdges.Add(edge);
        }

        internal void adInEdge(Edge edge)
        {
            inEdges.Add(edge);
        }

        internal int getOutEdgeCount()
        {
            return outEdges.Count;
        }

        public virtual void calculate()
        {
            updateNetIn();
            // call calculate delegate (usually sigmoid for perceptrons)
            netOut = calculateOutput(netIn);
        }

        protected void updateNetIn()
        {
            // If this node has input edges calcuate its net in
            if (inEdges.Count != 0)
            {
                netIn = 0;

                foreach (Edge edge in inEdges)
                {
                    netIn += edge.netOut;
                }
            }
        }


        /// <summary>
        /// During batch processing of instances updatedWeight will store the addition
        /// of all the error graidients for that weight. The weights should be updated
        /// only at the end of the batch.
        /// </summary>
        internal void refresh()
        {
            foreach (Edge edge in inEdges)
            {
                edge.updatedWeight = edge.weight;
            }
        }

        internal void backPropagate(double alpha, double actualValue)
        {
            dEdO = -1 * (actualValue - netOut);
            dOdN = netOut * (1 - netOut);

            foreach (Edge edge in inEdges)
            {
                double dNdW = edge.tail.netOut;
                edge.updatedWeight -= (alpha * dEdO * dOdN * dNdW);
            }
        }

        internal void backPropagate(double alpha)
        {
            dEdO = 0;
            dOdN = netOut * (1 - netOut);


            // dEdO is a summation of all the error created by all of the outgoing edges from this node
            foreach (Edge edge in outEdges)
            {
                Node head = edge.head;
                dEdO += head.dEdO * head.dOdN * edge.weight; // extract to function call to head?
            }

            foreach (Edge edge in inEdges)
            {
                double dNdW = edge.tail.netOut;
                edge.updatedWeight -= (alpha * dEdO * dOdN * dNdW);
            }
        }


        internal void update()
        {
            foreach (Edge edge in inEdges)
            {
                edge.update();
            }
        }


        public override string ToString()
        {
            String build = "{ ";
            foreach(Edge edge in inEdges)
            {
                build += Math.Round(edge.weight,4) + " ";
            }

            return build +"}";
        }
    }
}
