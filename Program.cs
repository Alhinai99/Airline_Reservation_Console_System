class AirlineReservationSystem
{
    // Max limits
    const int MaxFlights = 10;
    const int MaxBookings = 20;

    // Flight data
    static string[] flightCodes = new string[MaxFlights];
    static string[] fromCities = new string[MaxFlights];
    static string[] toCities = new string[MaxFlights];
    static DateTime[] departureTimes = new DateTime[MaxFlights];
    static int[] durations = new int[MaxFlights];
    static int flightCount = 0;

    // Booking data
    static string[] bookingIDs = new string[MaxBookings];
    static string[] passengerNames = new string[MaxBookings];
    static string[] bookedFlightCodes = new string[MaxBookings];
    static int bookingCount = 0;


    // Startup & Navigation (1–4)
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("=====Welcome to the Airline Reservation System!=========");

    }

    static int ShowMainMenu()
    {
        
        Console.WriteLine("=====Main Menu=====");

        Console.WriteLine("1. Book a Flight");
        Console.WriteLine("2. Cancel a Booking");
        Console.WriteLine("3. View All Flights");
        Console.WriteLine("4. View Flight Details");
        Console.WriteLine("5. Search Bookings by Destination");
        Console.WriteLine("6. add flight");
        Console.WriteLine("7. Exit");
        Console.Write("Select an option (1-7): ");
        int input = int.Parse(Console.ReadLine());
        Console.Clear();

        return input;
    }

    static void ExitApplication()
    {
        Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
        return;
    }

    static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
    {
        if (flightCount < MaxFlights)
        {
            flightCodes[flightCount] = flightCode;
            fromCities[flightCount] = fromCity;
            toCities[flightCount] = toCity;
            departureTimes[flightCount] = departureTime;
            durations[flightCount] = duration;
            flightCount++;
        }
        else
        {
            Console.WriteLine("Flight limit reached. Cannot add more flights.");
        }
    }

    // Flight and Passenger Management (5–8)
    static void DisplayAllFlights()
    {

        for (int i = 0; i < flightCount; i++)
        {
            Console.WriteLine("flight code : " + flightCodes[i]);
            Console.WriteLine("From: " + fromCities[i]);
            Console.WriteLine("To: " + toCities[i]);
            Console.WriteLine("Departure: " + departureTimes[i]);
            Console.WriteLine("Duration: " + durations[i] + " hours");
        }
    }

    static bool FindFlightByCode(string code)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i]== code)
            {
                Console.WriteLine("Flight found: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
                return true;
            }
        }
        return false;
    }

    static void UpdateFlightDeparture(ref DateTime departure)
    {
    }

    static void CancelFlightBooking(out string passengerName)
    {
        passengerName = "";
    }

    // Passenger Booking Functions (9–13)
    static void BookFlight(string passengerName, string flightCode = "Default001")
    {
    }

    static bool ValidateFlightCode(string flightCode)
    {
        return false;
    }

    static string GenerateBookingID(string passengerName)
    {
        return "";
    }

    static void DisplayFlightDetails(string code)
    {
    }

    static void SearchBookingsByDestination(string toCity)
    {
    }

    // Function Overloading (14 – 16)
    static int CalculateFare(int basePrice, int numTickets)
    {
        return 0;
    }

    static double CalculateFare(double basePrice, int numTickets)
    {
        return 0.0;
    }

    static int CalculateFare(int basePrice, int numTickets, int discount)
    {
        return 0;
    }

    // System Utilities & Final Flow (17 – 18)
    static bool ConfirmAction(string action)
    {
        return false;
    }

    static void StartSystem()
    {
        DisplayWelcomeMessage();
        
        while (true)
        {
            int choice = ShowMainMenu();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter passenger name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter flight code (optional): ");
                    string code = Console.ReadLine();
                    BookFlight(name, string.IsNullOrEmpty(code) ? "Default001" : code);
                    break;

                case 2:
                    if (ConfirmAction("cancel this booking"))
                    {
                        CancelFlightBooking(out string cancelled);
                        Console.WriteLine($"Cancelled booking for: {cancelled}");
                    }
                    break;

                case 3:
                    DisplayAllFlights();
                    break;

                case 4:
                    Console.Write("Enter flight code: ");
                    string fcode = Console.ReadLine();
                    DisplayFlightDetails(fcode);
                    break;

                case 5:
                    Console.Write("Enter destination city: ");
                    string city = Console.ReadLine();
                    SearchBookingsByDestination(city);
                    break;


                case 6:
                    Console.WriteLine("Adding a new flight...");
                    Console.Write("Flight Code: ");
                    string flightCode = Console.ReadLine();
                    Console.Write("From City: ");
                    string fromCity = Console.ReadLine();
                    Console.Write("To City: ");
                    string toCity = Console.ReadLine();
                    Console.Write("Departure Time (yyyy-mm-dd hh:mm): ");
                    DateTime departureTime = DateTime.Parse(Console.ReadLine());
                    Console.Write("Duration (in hourse): ");
                    int duration = int.Parse(Console.ReadLine());
                    AddFlight(flightCode, fromCity, toCity, departureTime, duration);
                    break;
                case 7:
                    ExitApplication();
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Entry point
    static void Main(string[] args)
    {
        StartSystem();
    }
}

