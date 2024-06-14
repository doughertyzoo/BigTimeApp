using System.ComponentModel.DataAnnotations;

namespace BigTimeApi
{
    public class BaseCustomerRequestModel
    {
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        public Address? Address { get; set; }
    }
}
