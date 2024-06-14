using System.ComponentModel.DataAnnotations;

namespace BigTimeApi
{
    public class UpdateCustomerRequestModel : BaseCustomerRequestModel
    {
        [Required]
        public int CustomerId { get; set; }
    }
}
