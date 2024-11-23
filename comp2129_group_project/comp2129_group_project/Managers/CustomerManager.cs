using comp2129_group_project.Entities;
using static comp2129_group_project.Validation.Validation;
using static comp2129_group_project.Entities.Constants;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.Managers
{
    public class CustomerManager
    {
        private static readonly FileManager _fileManager = new();
        private readonly int maxCustomers;

        public CustomerManager(int maxCustomers)
        {
            this.maxCustomers = maxCustomers;
        }

        // Get the current count of customers
        private int GetCustomerCount()
        {
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);
            return fileContent.Count(line => !string.IsNullOrWhiteSpace(line));
        }

        // Validate and format phone number
        public static string ValidateAndFormatPhoneNumber(string phoneNumber)
        {
            string cleanedNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (cleanedNumber.Length != 10)
            {
                Console.WriteLine("Invalid phone number. Please enter exactly 10 digits.");
                return "";
            }

            return $"({cleanedNumber.Substring(0, 3)}) {cleanedNumber.Substring(3, 3)}-{cleanedNumber.Substring(6)}";
        }

        // Add new customer
        public void AddNewCustomer()
        {
            int customerCount = GetCustomerCount();

            if (customerCount >= maxCustomers)
            {
                Console.WriteLine("The customer list is full. We are unable to add more customers at this time.");
                Console.ReadKey();
                return;
            }

            // First Name Validation
            string firstName;
            while (true)
            {
                Console.WriteLine("Please enter the customer's first name:");
                firstName = Console.ReadLine()!;
                if (ValidateName(firstName))
                {
                    Console.WriteLine("First name is valid.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid first name.");
                }
            }

            // Last Name Validation
            string lastName;
            while (true)
            {
                Console.WriteLine("Please enter the customer's last name:");
                lastName = Console.ReadLine()!;
                if (ValidateName(lastName))
                {
                    Console.WriteLine("Last name is valid.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid last name.");
                }
            }

            // Phone Number Validation
            string phoneNum;
            while (true)
            {
                Console.WriteLine("Please enter the customer's 10-digit phone number (spaces, dashes, or dots can be used as separators):");
                phoneNum = ValidateAndFormatPhoneNumber(Console.ReadLine()!);
                if (!string.IsNullOrEmpty(phoneNum))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number.");
                }
            }

            try
            {
                int id = GetCustomerId();
                Customer customer = new(id, firstName, lastName, phoneNum);

                if (CustomerExists(customer))
                {
                    Console.WriteLine($"A customer with the name {firstName} {lastName} already exists.");
                    Console.ReadKey();
                    return;
                }

                string content = $"{customer.CustomerId}:{firstName}:{lastName}:{phoneNum}";
                _fileManager.AppendFile(CUSTOMERS_FILE, content);

                customerCount++;

                Console.WriteLine($"\n-------------------------------------------------");
                Console.WriteLine($"Customer {firstName} {lastName} has been successfully added.");
                Console.WriteLine($"-------------------------------------------------");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: Unable to process the request: {ex.Message}");
            }

            Console.ReadKey();
        }

        // View customers information
        public void ViewCustomersInformation()
        {
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE)
                                               .Where(line => !string.IsNullOrWhiteSpace(line))
                                               .ToArray();

            if (fileContent.Length == 0)
            {
                Console.WriteLine("\nNo customers found.");
            }
            else
            {
                DisplayAllCustomers(fileContent);
            }
            Console.ReadKey();
        }

        // Get the next available customer ID
        public int GetCustomerId()
        {
            string[] contents = _fileManager.ReadFile(CUSTOMERS_FILE);
            int maxId = 0;

            foreach (var line in contents)
            {
                if (string.IsNullOrEmpty(line)) continue;

                var parts = line.Split(":");
                if (int.TryParse(parts[0], out int id) && id > maxId)
                {
                    maxId = id;
                }
            }

            return maxId + 1;
        }

        // Find customer by ID
        public Customer? FindCustomerInformationById(string customerId)
        {
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);

            foreach (string line in fileContent)
            {
                if (string.IsNullOrEmpty(line)) continue;

                string[] parts = line.Split(":");
                if (parts[0] == customerId)
                {
                    return new Customer(int.Parse(parts[0]), parts[1], parts[2], parts[3]);
                }
            }

            return null;
        }

        // Delete customer
        public void DeleteCustomer()
        {
            if (GetCustomerCount() == 0)
            {
                Console.WriteLine("There are no customers available to delete.");
                Console.ReadKey();
                return;
            }

            ViewCustomersInformation();

            Console.WriteLine("Please enter the customer ID of the customer you would like to delete:");
            Console.Write("> ");
            string customerIdToDelete = Console.ReadLine();

            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE);
            if (fileContent == null || fileContent.Length == 0)
            {
                Console.WriteLine("The customer file is empty or could not be read.");
                Console.ReadKey();
                return;
            }

            string[] updatedFileContent = fileContent.Where(line => !line.Contains(customerIdToDelete)).ToArray();

            if (updatedFileContent.Length == fileContent.Length)
            {
                Console.WriteLine($"No customer with ID {customerIdToDelete} was found.");
                Console.ReadKey();
                return;
            }

            _fileManager.DeleteFile(CUSTOMERS_FILE);

            foreach (var line in updatedFileContent)
            {
                if (!string.IsNullOrWhiteSpace(line)) 
                {
                    _fileManager.AppendFile(CUSTOMERS_FILE, line);
                }
            }

            Console.WriteLine($"Customer with ID {customerIdToDelete} has been successfully deleted.");
            Console.ReadKey();

            Console.WriteLine("\nUpdated Customer List:");
            ViewCustomersInformation();
        }

        // Check if a customer exists in the file
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
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] x = line.Split(":");

                    if (x[0] == customer.FirstName && x[1] == customer.LastName && x[2] == customer.Phone)
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
