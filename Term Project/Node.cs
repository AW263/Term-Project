using System;
using System.Collections.Generic;
using System.Text;

namespace Term_Project
{
   public class Node
    {
        private Delivery element;
        private Node next;
        public Delivery Element
        {
            get { return element; }
            set { element = value; }
        }
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node(Delivery element, Node prevNode)
        {
            Element = element;
            prevNode.Next = this;
            next = null;
        }
        public Node(Delivery element)
        {
            Element = element;
            next = null;
        }
    }
}
