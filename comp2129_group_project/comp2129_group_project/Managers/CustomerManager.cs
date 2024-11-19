using comp2129_group_project.Entities;
using static comp2129_group_project.Validation.Validation;
using static comp2129_group_project.Entities.Constants;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.Managers
{
    public class CustomerManager(int maxCustomers)
    {
        private static readonly FileManager _fileManager = new();
        private int customerCount = _fileManager.ReadFile(CUSTOMERS_FILE).Length - 1;
        private readonly int maxCustomers = maxCustomers;

        public void AddNewCustomer()
        {
            if (customerCount >= maxCustomers)
            {
                Console.WriteLine("Sorry to inform you that customer list is full. At this time we cannot add more customers.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please enter the first name of the customer: ");
            string firstName = Console.ReadLine()!;

            Console.WriteLine("Please enter the last name of the customer: ");
            string lastName = Console.ReadLine()!;

            Console.WriteLine("Please enter phone number for the customer: ");            
            string phoneNum = ValidatePhoneNum(Console.ReadLine()!);

            try
            {
                Customer customer = new(firstName, lastName, phoneNum);

                bool exists = CustomerExists(customer);

                if (exists)
                {
                    CustomerExistsMsg();
                    return;
                }

                string content = $"{firstName}:{lastName}:{phoneNum}";

                _fileManager.AppendFile(CUSTOMERS_FILE, content);

                customerCount++;

                Console.WriteLine($"\n-------------------------------------------------");
                Console.WriteLine($"Customer {firstName} has been added successfully.");
                Console.WriteLine($"-------------------------------------------------");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: Sorry but we are unable to process at this time: {ex.Message}");
            }

            Console.ReadKey();
        }

        public void ViewCustomersInformation()
        {   
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE)
                                       .Where(line => !string.IsNullOrWhiteSpace(line)) // Exclude blank lines
                                       .ToArray();
            
            if (customerCount == 0)
            {
                Console.WriteLine("\nSorry but we could not find any customers with that informaiton you have provided.");
            }
            else
            {

                DisplayAllCustomers(fileContent); 
            }
            Console.ReadKey();
        }

        public Customer? FindCustomerById(string customerId)
        {
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);

            foreach (string line in fileContent)
            {
                if (string.IsNullOrEmpty(line)) continue;

                // Each line format: FirstName:LastName:Phone
                string[] parts = line.Split(":");
                string currentCustomerId = parts[0]; // Assuming Customer ID is stored in the first part

                if (currentCustomerId == customerId)
                {
                    // Return a matching Customer object
                    return new Customer(parts[0], parts[1], parts[2]);
                }
            }

            // No matching customer found
            return null;
        }

        public void DeleteCustomer()
        {
            if (customerCount == 0)
            {
                return;
            }

            ViewCustomersInformation();

            Console.WriteLine("Please enter the customer number that you would like to delete:");
            Console.Write("> ");

            try
            {
                string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);

                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= customerCount)
                {
                    int indexToRemove = index - 1;
                    
                    // Removing customer from the array
                    string[] newContent = fileContent.Where((source, x) => x != indexToRemove).ToArray();

                    // Delete file before writing new data to it
                    _fileManager.DeleteFile(CUSTOMERS_FILE);

                    // Append each line of new array to the file
                    foreach (string item in newContent)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            _fileManager.AppendFile(CUSTOMERS_FILE, item);
                        }
                    }

                    customerCount--;

                    Console.WriteLine("\n---------------------------------------");
                    Console.WriteLine("Customer has been deleted successfully.");
                    Console.WriteLine("---------------------------------------");
                }
                else
                {
                    Console.WriteLine("Sorry but this is an invalid selection. Please try again.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        // Check if any of the fields already exist in the file
        private static bool CustomerExists(Customer customer)
        {
            try
            {
                string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);

                if (string.IsNullOrEmpty(fileContent.First()))
                {
                    return false;
                }

                foreach (string line in fileContent)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] x = line.Split(":");

                    if (x[0] == customer.FirstName)
                    {
                        return true;
                    }
                    else if (x[1] == customer.LastName)
                    {
                        return true;
                    }
                    else if (x[2] == customer.Phone)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
