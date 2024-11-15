using comp2129_group_project.Entities;

namespace comp2129_group_project
{
    public class CustomerManager
    {
        // Create customer objects to populate array
        private Customer[] customers;
        private int customernumCount;

        public CustomerManager(int maxiumCustomers)
        {
            //customers = new string[maxiumCustomers];
            customernumCount = 0;
        }

        public void AddCustomer()
        {
            if (customernumCount >= customers.Length)
            {
                Console.WriteLine("Sorry to inform you that customer list is full. At this time we cannot add more customers.");
                Console.ReadKey();
                return;
            }

            Console.Write("Please enter a customer name: ");

            string customerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(customerName))
            {
                Console.WriteLine("Sorry but customer name cannot be empty. You need to add an text");
                Console.ReadKey();
                return;
            }

            //customers[customernumCount] = customerName;
            customernumCount++;
            Console.WriteLine("The customer has been added successfully.");
            Console.ReadKey();
        }

        public void ViewCustomersInformation()
        {
            Console.WriteLine("Customer List:");
            if (customernumCount == 0)
            {
                Console.WriteLine("Sorry but we could not find this customers.");
            }
            else
            {
                for (int k = 0; k < customernumCount; k++)
                {
                    Console.WriteLine($"{k + 1}. {customers[k]}");
                }
            }
            Console.ReadKey();
        }

        public void DeleteCustomer()
        {
            ViewCustomersInformation();
            if (customernumCount == 0)
            {
                return;
            }

            Console.Write("Please enter the customer number that you would like to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= customernumCount)
            {
                for (int k = index - 1; k < customernumCount - 1; k++)
                {
                    customers[k] = customers[k + 1];
                }

                customers[customernumCount - 1] = null;
                customernumCount--;
                Console.WriteLine("Customer has been deleted successfully.");
            }
            else
            {
                Console.WriteLine("Sorry but this is an invalid selection. Please try again.");
            }
            Console.ReadKey();
        }
    }
}