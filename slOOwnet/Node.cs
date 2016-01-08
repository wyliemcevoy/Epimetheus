using System.Collections.Generic;

namespace slOOwnet
{
    class Node
    {
        private List<Edge> outEdges;
        private List<Edge> inEdges;

        public delegate double CalculateOutputDelegate(double input);
        public CalculateOutputDelegate calculateOutput { get; set; }

        public double netIn { get; set; }
        public double netOut { get; set; }

        public Node()
        {
            outEdges = new List<Edge>();
            inEdges = new List<Edge>();
            calculateOutput = new CalculateOutputDelegate(setOutputToInput);
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
            // for input layer nodes and output layer nodes netOut equals netIn
            netOut = calculateOutput(netIn);
        }

        private double setOutputToInput(double input)
        {
            return input;
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
    }
}
