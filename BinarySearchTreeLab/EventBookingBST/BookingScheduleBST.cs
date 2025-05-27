using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTreeLab;

namespace EventBookingBST
{
    /// <summary>
    /// Provides scheduling and event management functionality using a Binary Search Tree (BST) for Event objects.
    /// </summary>
    internal class BookingScheduleBST
    {
        private BinarySearchTree<Event> bst;

        /// <summary>
        /// Initializes a new instance of the BookingScheduleBST class.
        /// </summary>
        public BookingScheduleBST()
        {
            this.bst = new BinarySearchTree<Event>();
        }

        /// <summary>
        /// Adds a new event to the schedule.
        /// </summary>
        /// <param name="ev">The event to add.</param>
        public void AddEvent(Event ev)
        {
            this.bst.AddRecursive(ev);
        }

        /// <summary>
        /// Searches for an event in the schedule by its date and time.
        /// </summary>
        /// <param name="ev">The event to search for (matching by date and time).</param>
        /// <returns>True if the event is found; otherwise, false.</returns>
        public bool SearchEvent(Event ev)
        {
            return this.bst.SearchRecursive(ev);
        }

        /// <summary>
        /// Deletes an event from the schedule by its date and time.
        /// </summary>
        /// <param name="ev">The event to delete (matching by date and time).</param>
        public void DeleteEvent(Event ev)
        {
            this.bst.DeleteRecursive(ev);
        }

        /// <summary>
        /// Finds the next available event after the specified date and time.
        /// </summary>
        /// <param name="afterTime">The date and time to search after.</param>
        /// <returns>The next available Event after the given time, or null if none exists.</returns>
        public Event FindNextAvailableEvent(DateTime afterTime)
        {
            return FindNextAvailableEventHelper(this.bst.Root, afterTime);
        }

        /// <summary>
        /// Helper method to find the next available event after a specified time (used recursively).
        /// </summary>
        private Event FindNextAvailableEventHelper(TreeNode<Event> node, DateTime afterTime)
        {
            Event candidate = null;
            while (node != null)
            {
                if (node.Value.Date > afterTime)
                {
                    candidate = node.Value;
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return candidate;
        }

        /// <summary>
        /// Displays all events scheduled after the specified date and time.
        /// </summary>
        /// <param name="afterTime">The date and time to show events after.</param>
        public void ShowEventsAfter(DateTime afterTime)
        {
            ShowEventsAfterHelper(this.bst.Root, afterTime);
        }

        /// <summary>
        /// Helper method to recursively display all events after a given time.
        /// </summary>
        private void ShowEventsAfterHelper(TreeNode<Event> node, DateTime afterTime)
        {
            if (node == null) return;

            // Since it's BST by Date, go left if there's chance of bigger date
            if (node.Value.Date > afterTime)
            {
                ShowEventsAfterHelper(node.Left, afterTime);
                Console.WriteLine(node.Value);
                ShowEventsAfterHelper(node.Right, afterTime);
            }
            else
            {
                ShowEventsAfterHelper(node.Right, afterTime);
            }
        }

        /// <summary>
        /// Displays all events in the schedule in sorted order (in-order traversal).
        /// </summary>
        public void ShowAllEvents()
        {
            ShowAllEventsHelper(this.bst.Root);
        }

        /// <summary>
        /// Helper method to recursively display all events in sorted order.
        /// </summary>
        private void ShowAllEventsHelper(TreeNode<Event> node)
        {
            if (node == null) return;
            ShowAllEventsHelper(node.Left);
            Console.WriteLine(node.Value);
            ShowAllEventsHelper(node.Right);
        }
    }
}
