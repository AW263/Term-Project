using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Term_Project
{
    public class Delivered 
    {
        private Node head;
        private Node tail;
        private int count;
        public Delivered()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public void Add(Delivery item)
        {
            if (head == null)
            {
                head = new Node(item);
                tail = head;
            }
            else
            {
                Node newNode = new Node(item, tail);
                tail = newNode;
            }
            Count++;
        }

        public int Remove(int id)
        {
            Node current = head;
            Node prev = null;
            int countIndexes = 0;
            bool isFound = false;
            while (current.Next != null)
            {
                if (current.Element.Id.Equals(id))
                {
                    isFound = true;
                    break;

                }
                prev = current;
                current = current.Next;
                countIndexes++;
            }
            if (countIndexes == 0)
            {
                head = current.Next;
                count--;
            }
            else if (tail.Element.Equals(id))
            {
                prev.Next = null;
                tail = prev;
                countIndexes = count - 1;
                count--;
            }
            else if (isFound)
            {
                prev.Next = current.Next;
            }
            else
                countIndexes = -1;
            if (count == 0)
            {
                {
                    head = null;
                    tail = null;
                }
            }
            return countIndexes;
        }
        public int IndexOf(int id)
        {
            Node current = head;
            int currentI = 0;
            while (current.Next != null)
            {
                if (current.Element.Id.Equals(id))
                {
                    return currentI;
                }
                current = current.Next;
                currentI++;
            }
            return -1;
        }
        public bool Contains(int id)
        {
            int index = IndexOf(id);
            if (index != -1)
                return true;
            return false;
        }
        public object this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node current = this.head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Element;
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                Node current = this.head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Element = (Delivery)value;
            }
        }
        public void Status(int id)
        {
            Node current = head;
            bool IsTrue = false;
            while (current.Next != null)
            {
                if (current.Element.Id.Equals(id))
                {
                    IsTrue = true;
                    break;

                }
                current = current.Next;
            }
            if (IsTrue == true)
                Console.WriteLine("Wrong id");
            else
                Console.WriteLine("The items are delivered");
        }
        public void Redirect(int id, string country, string city, string street, int number)
        {
            Node current = head;

            while (current.Next != null)
            {
                if (current.Element.Id.Equals(id))
                {

                    break;

                }
            }
            current.Element.Country = country;
            current.Element.City = city;
            current.Element.Street = street;
            current.Element.Number = number;
        }
        public void ChangePerson(int id, string fisrtName, string lastName)
        {
            Node current = head;
            while (current.Next != null)
            {
                if (current.Element.Id.Equals(id))
                {

                    break;

                }
            }
            current.Element.FirstName = fisrtName;
            current.Element.LastName = lastName;

        }

        public IEnumerator<Delivery> GetEnumerator()
        {
            Node current = head;
           
            while (current.Next != null)
            {
                yield return current.Element;
               
                current = current.Next;
            }
            yield return current.Element;
        }

        

       

        

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }
    }
}
