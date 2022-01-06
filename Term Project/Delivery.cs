using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Term_Project
{
    public class Delivery:IComparable<Delivery>
    {
        private string country;
        private string city;
        private string street;
        private int number;
        private Dictionary<string, int> items;
        private bool delivered;
        private int id;
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }



        public Delivery(string country, string city, string street, int number, bool delivered, int id, string firstName, string lastName)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
           
            Delivered = delivered;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool Delivered
        {
            get { return delivered; }
            set { delivered = value; }
        }

        public Dictionary<string, int> Items
        {
            get { return items; }
            set { items = value; }
        }


        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }


        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public int CompareTo(Delivery other)
        {
            var result = Country.CompareTo(other.Country);
            if (result == 0)
                result = City.CompareTo(other.City);
            return result;
        }
        public override string ToString()
        {
            return $"{Country}: {City}";
        }
    }
}
