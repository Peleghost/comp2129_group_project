using comp2129_group_project.Entities;
using static comp2129_group_project.Validation.Validation;
using static comp2129_group_project.Entities.Constants;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.Managers
{
    public class CustomerManager
    {
        private static readonly FileManager _fileManager = new();
        private int customerCount = _fileManager.ReadFile(CUSTOMERS_FILE).Length - 1;
        private readonly int maxCustomers;

        public CustomerManager(int maxCustomers)
        {
            this.maxCustomers = maxCustomers;
        }

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

        public void AddNewCustomer()
        {
            if (customerCount >= maxCustomers)
            {
                Console.WriteLine("The customer list is full. We are unable to add more customers at this time.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please enter the customer's first name:");
            string firstName = Console.ReadLine()!;

            Console.WriteLine("Please enter the customer's last name:");
            string lastName = Console.ReadLine()!;

            Console.WriteLine("Please enter the customer's 10-digit phone number (spaces, dashes, or dots can be used as separators):");
            string phoneNum = ValidateAndFormatPhoneNumber(Console.ReadLine()!);

            if (string.IsNullOrEmpty(phoneNum))
            {
                return;
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

        public void ViewCustomersInformation()
        {
            string[] fileContent = _fileManager.ReadFile(CUSTOMERS_FILE)
                                               .Where(line => !string.IsNullOrWhiteSpace(line))
                                               .ToArray();

            if (customerCount == 0)
            {
                Console.WriteLine("\nNo customers found.");
            }
            else
            {
                DisplayAllCustomers(fileContent);
            }
            Console.ReadKey();
        }

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

        public void DeleteCustomer()
        {
            if (customerCount == 0)
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
                _fileManager.AppendFile(CUSTOMERS_FILE, line);
            }

            Console.WriteLine($"Customer with ID {customerIdToDelete} has been successfully deleted.");
            Console.ReadKey();

            Console.WriteLine("\nUpdated Customer List:");
            ViewCustomersInformation();
        }

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
