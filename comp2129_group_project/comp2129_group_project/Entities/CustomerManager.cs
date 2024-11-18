using System;
using comp2129_group_project.Entities;

namespace comp2129_group_project
{
    public class CustomerManager
    {
        private Customer[] customers;
        private int customernumCount;

        public CustomerManager(int maxiumCustomers)
        {
            customers = new Customer[maxiumCustomers];
            customernumCount = 0;
        }

        public void AddanewCustomer()
        {
            if (customernumCount >= customers.Length)
            {
                Console.WriteLine("Sorry to inform you that customer list is full. At this time we cannot add more customers.");
                Console.ReadKey();
                return;
            }

            Console.Write("Please enter the first name of the customer: ");
            string firstName = Console.ReadLine();

            Console.Write("Please enter the last name of the customer (or leave blank): ");
            string lastName = Console.ReadLine();

            try
            {
                Customer newCustomer = new Customer(firstName, lastName);
                customers[customernumCount] = newCustomer;
                customernumCount++;
                Console.WriteLine($"Customer {newCustomer} has been added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: Sorry but we are unable to process at this time: {ex.Message}");
            }

            Console.ReadKey();
        }

        public void ViewCustomersInformation()
        {
            Console.WriteLine("Customer List:");
            if (customernumCount == 0)
            {
                Console.WriteLine("Sorry but we could not find any customers with that informaiton you have provided.");
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

        public bool CheckFirstName(string firstName)
        {
            for (int i = 0; i < customernumCount; i++)
            {
                if (customers[i]?.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
