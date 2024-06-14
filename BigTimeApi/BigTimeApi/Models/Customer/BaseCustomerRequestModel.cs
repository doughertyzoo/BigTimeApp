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
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
