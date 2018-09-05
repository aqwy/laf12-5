using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf12_5
{
    class Program
    {
        public static string getString()
        {
            string str = Console.ReadLine();
            return str;
        }
        public static char getChar()
        {
            string str = getString();
            return str[0];
        }
        public static int getInt()
        {
            string str = getString();
            return Int32.Parse(str);
        }
        static void Main(string[] args)
        {
            int value;
            HeapTree theHeap = new HeapTree(); // make a TreeHeap;
            bool success;
            theHeap.insert(70);
            theHeap.insert(40);
            theHeap.insert(50);
            theHeap.insert(20);
            theHeap.insert(60);
            theHeap.insert(100);
            theHeap.insert(80);
            theHeap.insert(30);
            theHeap.insert(10);
            theHeap.insert(90);
            bool b = true;
            while (b) // until [Ctrl]-[C]
            {
                Console.Write("Enter first letter of ");
                Console.Write("show, insert, remove, quit: ");
                int choice = getChar();
                switch (choice)
                {
                    case 's': // show
                        theHeap.displayHeap();
                        break;
                    case 'i': // insert
                        Console.Write("Enter value to insert: ");
                        value = getInt();
                        success = theHeap.insert(value);
                        if (!success)
                            Console.WriteLine("Can't insert; heap full");
                        break;
                    case 'r': // remove
                        if (!theHeap.isEmpty())
                            theHeap.remove();
                        else
                            Console.WriteLine("Can't remove; heap empty");
                        break;
                    case 'q':
                        b = false;
                        Console.WriteLine("quit!byebye!");
                        break;
                    default:
                        Console.WriteLine("Invalid entry\n");
                        break;
                } // end switch
            }
            Console.ReadLine();
        }
    }
}
