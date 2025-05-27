namespace EventBookingBST
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            BookingScheduleBST bookingSchedule = new BookingScheduleBST();
            bool running = true;

            Console.WriteLine("Välkommen till Event Booking System med BST!\n");

            while (running)
            {
                Console.WriteLine("\n--- Meny ---");
                Console.WriteLine("1. Lägg till event");
                Console.WriteLine("2. Sök event (på exakt datum och tid)");
                Console.WriteLine("3. Ta bort event");
                Console.WriteLine("4. Hitta nästa tillgängliga event efter tidpunkt");
                Console.WriteLine("5. Visa alla event efter viss tidpunkt");
                Console.WriteLine("6. Visa alla event (sorterade)");
                Console.WriteLine("7. Avsluta");
                Console.WriteLine("8. Lägg till demo-events automatiskt");
                Console.Write("Välj ett alternativ: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Ange event-namn: ");
                        string name = Console.ReadLine();
                        DateTime dateAdd = PromptForDateTime("Ange datum och tid (ex: 2024-06-15 14:00): ");
                        bookingSchedule.AddEvent(new Event(name, dateAdd));
                        Console.WriteLine("Event tillagt!");
                        break;

                    case "2":
                        Console.Write("Ange event-namn: ");
                        string searchName = Console.ReadLine();
                        DateTime dateSearch = PromptForDateTime("Ange datum och tid för event att söka: ");
                        bool exists = bookingSchedule.SearchEvent(new Event(searchName, dateSearch));
                        Console.WriteLine(exists ? "Eventet finns bokat!" : "Eventet finns INTE.");
                        break;

                    case "3":
                        Console.Write("Ange event-namn: ");
                        string delName = Console.ReadLine();
                        DateTime delDate = PromptForDateTime("Ange datum och tid för event att ta bort: ");
                        bookingSchedule.DeleteEvent(new Event(delName, delDate));
                        Console.WriteLine("Event borttaget (om det fanns).");
                        break;

                    case "4":
                        DateTime nextTime = PromptForDateTime("Ange tidpunkt för att hitta nästa lediga event: ");
                        Event nextEvent = bookingSchedule.FindNextAvailableEvent(nextTime);
                        if (nextEvent != null)
                            Console.WriteLine($"Nästa event efter {nextTime}: {nextEvent.Name} {nextEvent.Date}");
                        else
                            Console.WriteLine("Inga event hittades efter denna tidpunkt.");
                        break;

                    case "5":
                        DateTime afterTime = PromptForDateTime("Ange tidpunkt för att visa alla event efter: ");
                        Console.WriteLine($"Event efter {afterTime}:");
                        bookingSchedule.ShowEventsAfter(afterTime);
                        break;

                    case "6":
                        Console.WriteLine("Alla event i systemet (sorterat):");
                        bookingSchedule.ShowAllEvents();
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Avslutar programmet...");
                        break;

                    case "8":
                        AddDemoEvents(bookingSchedule);
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        // Hjälpmetod för datum-tid-inmatning
        private static DateTime PromptForDateTime(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out date))
                    return date;
                else
                    Console.WriteLine("Fel format! Ange datum och tid som ex: 2024-06-15 14:00");
            }
        }

        // Lägger till några events automatiskt
        private static void AddDemoEvents(BookingScheduleBST bookingSchedule)
        {
            var demoEvents = new[]
            {
                new Event("Haircut", new DateTime(2024, 5, 1, 10, 30, 0)),
                new Event("Event 1", new DateTime(2024, 5, 15, 13, 0, 0)),
                new Event("Event 2", new DateTime(2024, 5, 20, 11, 0, 0)),
                new Event("Event 3", new DateTime(2024, 6, 1, 14, 0, 0)),
                new Event("Dentist", new DateTime(2024, 7, 10, 9, 0, 0)),
                new Event("Doctor", new DateTime(2024, 8, 2, 8, 45, 0)),
            };

            foreach (var ev in demoEvents)
                bookingSchedule.AddEvent(ev);

            Console.WriteLine("Demo-events har lagts till automatiskt!");
        }
    }
}
