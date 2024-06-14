using System.ComponentModel.DataAnnotations;

namespace BigTimeApi
{
    public class UpdateCustomerForm : CustomerFormBase
    {
        [Required]
        public int CustomerId { get; set; }
    }
}
