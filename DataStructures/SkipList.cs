using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class SkipList<T> where T : IComparable<T>
    {
        public class Node<T> where T : IComparable<T>
        {
            public T Value; // Value of the node
            public Node<T> Next; // Rightward connection
            public Node<T> Down; // Downward connection
            public int Height { get; } // Vertical height of the node

            public Node(T value)
            {
                Value = value;
                
                Random rand = new Random();
                Node<T> currentDown = this;
                while(rand.Next(2) == 1)
                {
                    currentDown = new Node<T>(value, currentDown);
                    Down = currentDown;
                    Height++;
                }
            }
            public Node(T value, Node<T> down)
            {
                Value = value;

                Down = down;
            }
        }
    }
}
