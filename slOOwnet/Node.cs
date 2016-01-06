using System.Collections.Generic;

namespace slOOwnet
{
    class Node
    {
        private List<Edge> outEdges;
        private List<Edge> inEdges;
        public double netIn { get; set; }
        public double netOut { get; set; }

        public Node()
        {
            outEdges = new List<Edge>();
            inEdges = new List<Edge>();
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

        public void calculate()
        {
            netIn = 0;
            foreach (Edge edge in outEdges)
            {
                netIn += edge.weight;
            }

            netOut = 1 / (1 + System.Math.Exp(netIn));
        }
    }
}
