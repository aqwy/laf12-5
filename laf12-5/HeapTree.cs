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
            Node nullNode = findNullNode();
            nullNode.iData = key;
            trickleUp(nullNode);
            currentSize++;
            return true;
        }
        public Node remove()
        {
            if (currentSize == 0)
                return null;

            int key = root.iData;
            if (currentSize == 1)
            {
                currentSize--;
                root = null;
            }
            else
            {
                Node lastNode = findLastNode();
                root.iData = lastNode.iData;
                trickleDown(root);
                currentSize--;
            }
            return new Node(key);
        }
        private Node findLastNode()
        {
            Node parentNode = root;
            Node lastNode = root;

            int[] path = getPath(currentSize);
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == 0)
                {
                    parentNode = lastNode;
                    lastNode = lastNode.leftChild;
                    if (i == path.Length - 1)
                    {
                        parentNode.leftChild = null;
                        lastNode.parent = null;
                        return lastNode;
                    }
                }
                else
                {
                    parentNode = lastNode;
                    lastNode = lastNode.rightChild;
                    if (i == path.Length - 1)
                    {
                        parentNode.rightChild = null;
                        lastNode.parent = null;
                        return lastNode;
                    }
                }
            }
            root = null;
            return lastNode;
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
            Node currentNode = root;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == 0)
                {
                    if (currentNode.leftChild != null)
                        currentNode = currentNode.leftChild;
                    else
                    {
                        currentNode.leftChild = nullNode;
                        nullNode.parent = currentNode;
                        return nullNode;
                    }
                }
                else
                {
                    if (currentNode.rightChild != null)
                        currentNode = currentNode.rightChild;
                    else
                    {
                        currentNode.rightChild = nullNode;
                        nullNode.parent = currentNode;
                        return nullNode;
                    }
                }
            }
            root = nullNode;
            return nullNode;
        }
        public int[] getPath(int nodeNumber)
        {
            if (nodeNumber == 0)
                return null;
            int level = (int)(Math.Log(nodeNumber) / Math.Log(2)) + 1;
            int[] binary = new int[level];
            while (nodeNumber >= 1)
            {
                binary[--level] = nodeNumber % 2;
                nodeNumber /= 2;
            }
            int[] path = new int[binary.Length - 1];
            Array.Copy(binary, 1, path, 0, path.Length);
            return path;
        }
        public void displayHeap()
        {

            if (root == null)
            {
                Console.WriteLine("heapArray: empty heap!");
                return;
            }
            Console.Write("heapArray: "); // array format
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();
                Console.Write(node.iData + " ");
                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                }
                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                }
            }
            Console.WriteLine();
            int nBlanks = 32;
            int itemsPerRow = 1;
            int column = 0;
            String dots = "...............................";
            Console.WriteLine(dots + dots); // dotted top line
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                if (column == 0) // first item in row?
                    for (int k = 0; k < nBlanks; k++)
                        Console.Write(' ');// preceding blanks
                Node node = queue.Dequeue(); // Node node = queue.remove();
                Console.Write(node.iData);
                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                }
                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                }
                if (queue.Count == 0) // done?
                    break;
                if (++column == itemsPerRow) // end of row?
                {
                    nBlanks /= 2; // half the blanks
                    itemsPerRow *= 2; // twice the items
                    column = 0; // start over on
                    Console.WriteLine(); ; // new row
                }
                else
                    // next item on row
                    for (int k = 0; k < nBlanks * 2 - 2; k++)
                        Console.Write(' '); // interim blanks
            } // end for
            Console.WriteLine("\n" + dots + dots); // dotted bottom line
        }
    }
}
