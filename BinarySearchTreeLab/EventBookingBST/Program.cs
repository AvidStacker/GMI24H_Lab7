namespace EventBookingBST
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Event Booking System using Binary Search Tree (BST)!");
            Console.WriteLine("This system allows you to manage events and bookings efficiently.");
            Console.WriteLine("You can add, search, and delete events using a binary search tree structure.");
            Console.WriteLine("Let's get started with your event management!");
            // Here you would typically initialize your BST and start accepting user input
            // for adding, searching, and deleting events.

            BookingScheduleBST bookingSchedule = new BookingScheduleBST();
            // Add some events
            Event haircutEvent = new Event("Haircut", new DateTime(2024, 5, 1, 10, 30, 0));
            bookingSchedule.AddEvent(haircutEvent);
            Event otherEvent1 = new Event("Event 1", new DateTime(2024, 5, 15, 13, 0, 0));
            bookingSchedule.AddEvent(otherEvent1);
            Event otherEvent2 = new Event("Event 2", new DateTime(2024, 5, 20, 11, 0, 0));
            bookingSchedule.AddEvent(otherEvent2);
            Event otherEvent3 = new Event("Event 3", new DateTime(2024, 6, 1, 14, 0, 0));
            bookingSchedule.AddEvent(otherEvent3);
            // Find the next available event after a given time
            DateTime startTime = new DateTime(2024, 5, 15, 13, 0, 0);
            Event nextAvailableEvent = bookingSchedule.FindNextAvailableEvent(startTime);
            if (nextAvailableEvent != null)
            {
                Console.WriteLine($"Next available event after {startTime}:
            { nextAvailableEvent.Name}
                at { nextAvailableEvent.Date}
                ");
            }
            else
            {
                Console.WriteLine($"No available event found after {startTime}");
            }
            // Show all events after a given date and time
            Console.WriteLine($"\nEvents after {startTime}:");
            bookingSchedule.ShowEventsAfter(startTime);
        }
    }
}
