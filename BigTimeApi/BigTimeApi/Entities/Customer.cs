namespace BigTimeApi
{
    internal class Customer : ICustomer
    {
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public Address Address { get; set; } = new Address();
    }

    public class CustomerDto : ICustomer
    {
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public Address Address { get; set; } = new Address();
    }
}
