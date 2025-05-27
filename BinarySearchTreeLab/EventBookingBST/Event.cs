using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace EventBookingBST
{
    /// <summary>
    /// Represents a single event with a name and date/time, used for event scheduling in a BST.
    /// </summary>
    internal class Event : IComparable<Event>
    {

        /// <summary>
        /// Gets the name or description of the event.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the date and time of the event.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Initializes a new instance of the Event class with the specified name and date/time.
        /// </summary>
        /// <param name="name">The name or description of the event.</param>
        /// <param name="date">The date and time of the event.</param>
        public Event(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }

        /// <summary>
        /// Compares this event to another event based on the event's date and time.
        /// </summary>
        /// <param name="other">The other event to compare to.</param>
        /// <returns>
        /// Less than zero if this event is earlier than the other;
        /// Zero if they occur at the same time;
        /// Greater than zero if this event is later than the other.
        /// </returns>
        public int CompareTo(Event other)
        {
            if (other == null) return 1;
            return this.Date.CompareTo(other.Date);
        }

        /// <summary>
        /// Returns a string that represents the current event (for easy display).
        /// </summary>
        /// <returns>A string in the format: "Name at Date".</returns>
        public override string ToString()
        {
            return $"{Name} at {Date}";
        }
    }
}
