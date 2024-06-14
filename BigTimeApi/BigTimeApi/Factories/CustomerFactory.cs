namespace BigTimeApi
{
    public class CustomerFactory : ICustomerFactory
    {
        public ICustomer CreateCustomer(CreateCustomerRequestModel model)
        {
            return new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyName = model.CompanyName,
                Address = model.Address ?? new Address()
            };
        }

        public ICustomer CreateCustomer(UpdateCustomerRequestModel model)
        {
            return new Customer
            {
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyName = model.CompanyName,
                Address = model.Address ?? new Address()
            };
        }
    }
}
