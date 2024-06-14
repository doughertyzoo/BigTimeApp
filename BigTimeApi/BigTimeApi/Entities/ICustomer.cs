namespace BigTimeApi
{
    public interface ICustomer
    {
        int? CustomerId { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? CompanyName { get; set; }
        Address Address { get; set; }
    }
}
