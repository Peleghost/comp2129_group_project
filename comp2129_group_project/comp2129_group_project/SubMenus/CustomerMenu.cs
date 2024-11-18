using comp2129_group_project.Managers;
using static comp2129_group_project.Display.Display;

namespace comp2129_group_project.SubMenus
{

    public static class CustomerMenu
    {
        private static readonly CustomerManager customerManager = new CustomerManager(5); // Maximum 10 customer

        public static void HandleCustomerMenu()
        { 
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                string input = MenuCustomers();

                switch (input)
                {
                    case "1": // Add a new customer
                        customerManager.AddNewCustomer();
                        break;

                    case "2": // View customers
                        customerManager.ViewCustomersInformation();
                        break;

                    case "3": // Delete a customer
                        customerManager.DeleteCustomer();
                        break;

                    case "0": // Back to Main Menu
                        backToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Sorry but this is an invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
