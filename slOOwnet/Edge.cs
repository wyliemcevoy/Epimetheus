using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slOOwnet
{
    class Edge
    {
        public Node head { get; set; }
        public Node tail { get; set; }
        public double weight { get; set; }
        public double updatedWeight { get; set; }

        public double netOut
        {
            get
            {
                return weight * tail.netOut;
            }
        }


        public Edge(Node tail, Node head)
        {
            this.tail = tail;
            this.head = head;
            weight = .5;
        }

        internal void update()
        {
            weight = updatedWeight;
        }
    }
}
