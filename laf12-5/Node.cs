using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_5
{
    class Node
    {
        public  int iData;
        public Node parent;
        public Node leftChild;
        public Node rightChild;
        public Node() { }
        public Node(int key)
        {
            iData = key;
        }
    }
}
