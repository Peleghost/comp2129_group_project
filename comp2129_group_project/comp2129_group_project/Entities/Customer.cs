namespace comp2129_group_project.Entities
{
    public class Customer
    {
        //private static int i = 0;

        public int CustomerId { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Phone { get; set; }
        public int NumOfBookings { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, string phone)
        {
            CustomerId = id;

            FirstName = string.IsNullOrWhiteSpace(firstName) 
                ? throw new ArgumentException("Sorry, but the First name cannot be empty.") 
                : firstName;

            LastName = string.IsNullOrWhiteSpace(lastName) 
                ? "This is an Unknown" 
                : lastName;

            Phone = phone;
        }

        // Serialize customer data as a single line
        public string Serialize()
        {
            return $"{CustomerId}:{FirstName}:{LastName}:{Phone}";
        }

        // *** NOT IN USE CURRENTLY
        // Deserialize customer data from a line
        //public static Customer Deserialize(string line)
        //{
        //    string[] parts = line.Split(':');
        //    if (parts.Length < 4)
        //    {
        //        throw new ArgumentException("Invalid customer data format.");
        //    }

        //    return new Customer(parts[1], parts[2], parts[3])
        //    {
        //        CustomerId = int.Parse(parts[0])
        //    };
        //}

        //public override string ToString()
        //{
        //    return $"{FirstName} {LastName}";
        //}
    }
}
