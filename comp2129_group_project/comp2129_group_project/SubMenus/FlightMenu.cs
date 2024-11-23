using comp2129_group_project.Managers;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.SubMenus
{
    public static class FlightMenu
    {
        private static FlightManager flightManager = new FlightManager(10); // Set max flights to 10 (or any other number)

        public static void HandleFlightMenu()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                string input = MenuFlights(); // Display the flight menu and get user input

                switch (input)
                {
                    case "1": // Add a new flight
                        flightManager.AddNewFlight();
                        break;

                    case "2": // View all flights
                        flightManager.ViewFlightsInformation();
                        break;

                    case "3": // View a particular flight
                        Console.Write("Enter Flight Number: ");
                        string flightNumber = Console.ReadLine();
                        flightManager.ViewParticularFlight(flightNumber);
                        break;

                    case "4": // Delete a flight

                        flightManager.DeleteFlight();
                        break;

                    case "5": // Back to Main Menu
                        backToMainMenu = true;
                        break;

                    default: // Invalid choice
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
