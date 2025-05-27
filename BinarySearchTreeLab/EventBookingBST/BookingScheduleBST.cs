using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTreeLab;

namespace EventBookingBST
{
    internal class BookingScheduleBST
    {
        private BinarySearchTree<Event> bst;

        public BookingScheduleBST()
        {
            this.bst = new BinarySearchTree<Event>();
        }

        // Add event
        public void AddEvent(Event ev)
        {
            this.bst.AddRecursive(ev);
        }

        // Search event (by exact Date)
        public bool SearchEvent(Event ev)
        {
            return this.bst.SearchRecursive(ev);
        }

        // Delete event (by exact Date)
        public void DeleteEvent(Event ev)
        {
            this.bst.DeleteRecursive(ev);
        }

        // Find next available event after specified time
        public Event FindNextAvailableEvent(DateTime afterTime)
        {
            return FindNextAvailableEventHelper(this.bst.Root, afterTime);
        }

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

        public void ShowEventsAfter(DateTime afterTime)
        {
            ShowEventsAfterHelper(this.bst.Root, afterTime);
        }

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

        public void ShowAllEvents()
        {
            ShowAllEventsHelper(this.bst.Root);
        }

        private void ShowAllEventsHelper(TreeNode<Event> node)
        {
            if (node == null) return;
            ShowAllEventsHelper(node.Left);
            Console.WriteLine(node.Value);
            ShowAllEventsHelper(node.Right);
        }
    }
}
