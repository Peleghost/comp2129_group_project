using System;
using comp2129_group_project.Entities;
using static comp2129_group_project.Validation.Validation;
using static comp2129_group_project.Entities.Constants;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.Managers
{
    public class FlightManager
    {
        private static readonly FileManager _fileManager = new();
        private Flight[] flights;
        private int flightCount;
        private readonly int maxFlights;

        public FlightManager(int maxFlights)
        {
            this.maxFlights = maxFlights;
            flights = new Flight[maxFlights];
            flightCount = _fileManager.ReadFile(FLIGHTS_FILE).Length - 1; // Initialize flight count
        }

        // Add a new flight
        public void AddNewFlight()
        {
            Console.Clear();
            Console.WriteLine("Adding a new flight...");

            // Check if the array is full
            if (flightCount >= maxFlights)
            {
                Console.WriteLine("Cannot add a new flight. Maximum flight limit reached.");
                Console.ReadKey();
                return;
            }

            // Collect flight details
            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine()!;
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine()!;

            // Create a new flight with random max seats and passengers
            Flight newFlight = new(origin, destination);

            // Prepare the content to be appended to the file
            string content = $"{newFlight.FlightId}:{origin}:{destination}:{newFlight.MaxSeats}:{newFlight.NumOfPassengers}";

            // Append the flight details to the file
            _fileManager.AppendFile(FLIGHTS_FILE, content);

            // Add the new flight to the flights array (optional, for internal tracking)
            flights[flightCount] = newFlight;
            flightCount++;

            Console.WriteLine($"Flight {newFlight.FlightId} successfully added!");
            Console.ReadKey();
        }

        // View all flights
        public void ViewFlightsInformation()
        {
            if (flightCount == 0)
            {
                Console.WriteLine("Sorry, but we could not find any flights.");
            }
            else
            {
                // Read flight information from the file
                string[] fileContent = _fileManager.ReadFile(FLIGHTS_FILE);

                DisplayAllFlights(fileContent); 
            }
            Console.ReadKey();
        }

        // View a particular flight
        public void ViewParticularFlight(string flightId)
        {
            Console.Clear();

            Flight? flight = FindFlightById(flightId);

            if (flight != null)
            {
                Console.WriteLine($"Flight Number: {flight.FlightId}");
                Console.WriteLine($"Origin: {flight.Origin}");
                Console.WriteLine($"Destination: {flight.Destination}");
                Console.WriteLine($"Seats: {flight.NumOfPassengers}/{flight.MaxSeats}");
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
            Console.ReadKey();
        }

        // Delete a flight
        public void DeleteFlight(string flightId)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flights[i].FlightId.ToString() == flightId)
                {
                    if (flights[i].NumOfPassengers > 0)
                    {
                        Console.WriteLine("Cannot delete a flight with passengers.");
                        Console.ReadKey();
                        return;
                    }

                    // Shift remaining flights in the array
                    for (int j = i; j < flightCount - 1; j++)
                    {
                        flights[j] = flights[j + 1];
                    }

                    flights[flightCount - 1] = null; // Clear the last element
                    flightCount--;

                    Console.WriteLine($"Flight {flightId} deleted successfully.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Flight not found.");
            Console.ReadKey();
        }

        // Find a flight by its ID
        public Flight? FindFlightById(string flightId)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flights[i]?.FlightId.ToString() == flightId)
                {
                    return flights[i];
                }
            }
            return null; // Flight not found
        }
    }
}