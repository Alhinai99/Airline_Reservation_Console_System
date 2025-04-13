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
    static int[] fare = new int[MaxFlights];
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
        Console.WriteLine("4. View Flight Details (by flight code)");
        Console.WriteLine("5. Search Bookings by Destination");
        Console.WriteLine("6. add flight");
        Console.WriteLine("7. Update Flight Departure");

        Console.WriteLine("8. Exit");
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
        Console.WriteLine("Enter flight code to update: ");
        string flightCode = Console.ReadLine();
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i] == flightCode)
            {
                departureTimes[i] = departure;
                Console.WriteLine("Flight departure updated successfully.");
                return;
            }
        }


    }

    public static void CancelFlightBooking(out string canceld)
    {
        Console.Write("Enter passenger name to cancel booking: ");
        canceld = Console.ReadLine(); // Assign a value to the out parameter

        for (int i = 0; i < bookingCount; i++)
        {
            if (passengerNames[i] == canceld)
            {
                bookingIDs[i] = null;
                bookedFlightCodes[i] = null;
                passengerNames[i] = null;
                bookingCount--;
                Console.WriteLine("Booking cancelled successfully.");
                return;
            }
        }

        Console.WriteLine("No booking found for the given passenger name.");
    }

    // Passenger Booking Functions (9–13)
    static void BookFlight(string passengerName, string flightCode = "Default001")
    {
        if (bookingCount < MaxBookings)
        {
            bookingIDs[bookingCount] = GenerateBookingID(passengerName);
            passengerNames[bookingCount] = passengerName;
            bookedFlightCodes[bookingCount] = flightCode;
            bookingCount++;
        }
        else
        {
            Console.WriteLine("Booking limit reached. Cannot book more flights.");
        }


    }

    static bool ValidateFlightCode(string flightCode)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i] == flightCode)
            {
                return true;
            }
        }
        return false;
    }

    static string GenerateBookingID(string passengerName)
    {

        string bookingID = "BID" + (bookingCount + 1).ToString("D4");
        return bookingID;

    }

    static void DisplayFlightDetails(string code)
    {
        for(int i =0; i< flightCount; i++)
        {
            if(code == flightCodes[i])
            {
                Console.WriteLine("Flight Code: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
                Console.WriteLine("Fare: " + fare[i]);
                Console.WriteLine("Booking Details: ");
                Console.WriteLine("Booking ID: " + bookingIDs[i]);
                Console.WriteLine("Passenger Name: " + passengerNames[i]);
                Console.WriteLine("price: " + fare[i]);



            }
        }
        
    }

    static void SearchBookingsByDestination(string toCity)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (toCities[i] == toCity)
            {
                Console.WriteLine("Flight found: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
            }
        }
    }

    // Function Overloading (14 – 16)
    static int CalculateFare(int basePrice, int numTickets)
    {
        int price = 0;
        for (int i = 0; i < numTickets; i++)
        {
            price += basePrice;
        }
        return price;
    }

    static double CalculateFare(double basePrice, int numTickets)
    {
        double price = 0;
        for (int i = 0; i < numTickets; i++)
        {
            price += basePrice;
        }
        return price;
    }

    static int CalculateFare(int basePrice, int numTickets, int discount)
    {
        int price = 0;
        basePrice *= discount / 100;
        for (int i = 0; i < numTickets; i++)
        {
            
            price += basePrice ;
        }

        return price;
    }

    // System Utilities & Final Flow (17 – 18)
    static bool ConfirmAction(string action)

    {
        Console.Write($"Are you sure you want to {action}? (y/n): ");
        string input = Console.ReadLine();
        if (input.ToLower() == "y")
        {
            return true;
        }
        else if (input.ToLower() == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
        }

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
                    if (code == null)
                    {
                        code = "Default001"; // Default flight code
                    }
                    if (ValidateFlightCode(code)) 
                    {
                        string bookingID = GenerateBookingID(name);
                        BookFlight(name, code);
                        Console.WriteLine($"Booking successful! Booking ID: {bookingID}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid flight code.");
                    }
                    Console.WriteLine("Enter number of ticket :");
                    int numTickets = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter fare :");
                    int fare = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter discount :");
                    int discount = int.Parse(Console.ReadLine());

                    CalculateFare(fare, numTickets, discount);





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
                    Console.Write("Enter flight code to update: ");
                    string updateCode = Console.ReadLine();
                    Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                    DateTime newDepartureTime = DateTime.Parse(Console.ReadLine());
                    UpdateFlightDeparture(ref newDepartureTime);
                    break;
                case 8:
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

