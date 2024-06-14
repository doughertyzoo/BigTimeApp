namespace BigTimeApi
{
    public class CustomerDto : ICustomer
    {
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public Address Address { get; set; } = new Address();
    }
}
