using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace EventBookingBST
{
    internal class Event : IComparable<Event>
    {

        public string Name { get; }
        public DateTime Date { get; }

        public Event(string name, DateTime date) 
        {
            this.Name = name;
            this.Date = date;
        }

        // Comparison based on Date for BST ordering
        public int CompareTo(Event other)
        {
            if (other == null) return 1;
            return this.Date.CompareTo(other.Date);
        }

        public override string ToString()
        {
            return $"{Name} at {Date}";
        }
    }
}
