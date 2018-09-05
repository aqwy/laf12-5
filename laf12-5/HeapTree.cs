using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_5
{
    class HeapTree
    {
        private Node root;
        private int currentSize;
        public HeapTree()
        {
            root = null;
            currentSize = 0;
        }
        public bool isEmpty()
        {
            return (currentSize == 0);
        }
        public bool insert(int key)
        {

            return true;
        }
        public void trickleUp(Node currentNode)
        {
            Node theParent = currentNode.parent;
            int key = currentNode.iData;
            while (currentNode != root)
            {
                if (theParent.iData >= key)
                    break;
                else
                {
                    currentNode.iData = theParent.iData;
                    currentNode = theParent;
                    theParent = theParent.parent;
                }
            }
            currentNode.iData = key;
        }
        public void trickleDown(Node currentNode)
        {
            int key = currentNode.iData;
            Node theParent = currentNode;
            Node top;
            while (theParent.leftChild != null)
            {
                top = theParent.leftChild;
                if (theParent.rightChild != null && theParent.rightChild.iData > theParent.leftChild.iData)
                    top = theParent.rightChild;
                if (top.iData <= key)
                    break;
                theParent.iData = top.iData;
                theParent = top;
            }
            theParent.iData = key;
        }
        public Node findNullNode()
        {
            Node nullNode = new Node();
            int[] path = getPath(currentSize + 1);
        }
        public int[] getPath(int nodeNumber)
        {
            if (nodeNumber == 0)
                return null;
            int level = (int)(Math.Log(nodeNumber) / Math.Log(2)) + 1;
            int[] binary = new int[level];
        }
    }
}
