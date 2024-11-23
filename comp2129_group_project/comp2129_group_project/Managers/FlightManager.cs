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
        private readonly Flight[] flights;
        private int flightCount;
        private readonly int maxFlights;

        public FlightManager(int maxFlights)
        {
            this.maxFlights = maxFlights;
            flights = new Flight[maxFlights];
            flightCount = _fileManager.ReadFile(FLIGHTS_FILE).Length - 1;
        }

        public void AddNewFlight()
        {
            Console.Clear();
            Console.WriteLine("Adding a new flight...");

            if (flightCount >= maxFlights)
            {
                Console.WriteLine("Maximum flight limit reached. Cannot add more flights.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine()!;

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine()!;

            Flight newFlight = new(origin, destination);

            string content = $"{newFlight.FlightId}:{origin}:{destination}:{newFlight.MaxSeats}:{newFlight.NumOfPassengers}";

            _fileManager.AppendFile(FLIGHTS_FILE, content);
            flights[flightCount] = newFlight;
            flightCount++;

            Console.WriteLine($"\nFlight {newFlight.FlightId} added successfully!");
            Console.ReadKey();
        }

        public void ViewFlightsInformation()
        {
            string[] fileContent = _fileManager.ReadFile(FLIGHTS_FILE)
                                               .Where(line => !string.IsNullOrWhiteSpace(line))
                                               .ToArray();

            if (fileContent.Length == 0)
            {
                Console.WriteLine("\nNo flights available at the moment.");
            }
            else
            {
                DisplayFlightsTable(fileContent); 
            }

            Console.ReadKey();
        }

        private void DisplayFlightsTable(string[] flights)
        {
            Console.WriteLine("\n+--------------------+--------------------+--------------------+------------+-------------------+");
            Console.WriteLine("| Flight ID          | Origin             | Destination        | Max Seats | Passengers        |");
            Console.WriteLine("+--------------------+--------------------+--------------------+------------+-------------------+");
            
            foreach (var flight in flights)
            {
                var parts = flight.Split(":");
                Console.WriteLine($"| {parts[0],-18} | {parts[1],-18} | {parts[2],-18} | {parts[3],-10} | {parts[4],-17} |");
            }

            Console.WriteLine("+--------------------+--------------------+--------------------+------------+-------------------+");
        }

        public void ViewParticularFlight(string flightId)
        {
            Console.Clear();
            Flight? flight = FindFlightById(flightId);

            if (flight != null)
            {
                Console.WriteLine("Found:");
                Console.WriteLine("+-------------------+---------------------------------+");
                Console.WriteLine("| Flight ID         | {0,-31} |", flight.FlightId);
                Console.WriteLine("| Origin            | {0,-31} |", flight.Origin);
                Console.WriteLine("| Destination       | {0,-31} |", flight.Destination);
                Console.WriteLine("| Seats             | {0,-31} |", $"{flight.NumOfPassengers}/{flight.MaxSeats}");
                Console.WriteLine("+-------------------+---------------------------------+");

            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
            Console.ReadKey();
        }

  public void DeleteFlight()
{
    if (flightCount == 0)
    {
        Console.WriteLine("No flights available to delete.");
        Console.ReadKey();
        return;
    }
    Console.WriteLine("Current Flights: ");
    Console.WriteLine("Press Enter to proceed with the next step.");
    ViewFlightsInformation();
    Console.WriteLine("Please enter the flight ID of the flight you would like to delete:");
    Console.Write("> ");
    string flightIdToDelete = Console.ReadLine();

    string[] fileContent = _fileManager.ReadFile(FLIGHTS_FILE);
    if (fileContent == null || fileContent.Length == 0)
    {
        Console.WriteLine("The flight file is empty or could not be read.");
        Console.ReadKey();
        return;
    }

    string[] updatedFileContent = fileContent.Where(line => !line.StartsWith(flightIdToDelete + ":")).ToArray();

    if (updatedFileContent.Length == fileContent.Length)
    {
        Console.WriteLine($"No flight with ID {flightIdToDelete} was found.");
        Console.ReadKey();
        return;
    }

    _fileManager.DeleteFile(FLIGHTS_FILE);

    foreach (var line in updatedFileContent)
    {
        if (!string.IsNullOrWhiteSpace(line)) 
        {
            _fileManager.AppendFile(FLIGHTS_FILE, line);
        }
    }

    Console.WriteLine($"Flight with ID {flightIdToDelete} has been successfully deleted.");
    Console.ReadKey();

    Console.WriteLine("\nUpdated Flight List:");
    ViewFlightsInformation();
}


        private void UpdateFlightFile()
        {
            _fileManager.DeleteFile(FLIGHTS_FILE);

            for (int i = 0; i < flightCount; i++)
            {
                if (flights[i] != null)
                {
                    string content = $"{flights[i].FlightId}:{flights[i].Origin}:{flights[i].Destination}:{flights[i].MaxSeats}:{flights[i].NumOfPassengers}";
                    _fileManager.AppendFile(FLIGHTS_FILE, content);
                }
            }
        }

        public Flight? FindFlightById(string flightId)
        {
            foreach (string line in _fileManager.ReadFile(FLIGHTS_FILE))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(":");
                if (parts[0].Equals(flightId, StringComparison.OrdinalIgnoreCase))
                {
                    return new Flight(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                }
            }

            return null;
        }
    }
}
