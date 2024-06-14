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
                Address = CreateAddress(model)
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
                Address = CreateAddress(model)
            };
        }

        private Address CreateAddress(BaseCustomerRequestModel model)
        {
            return new Address
            {
                Street = model.Street,
                City = model.City,
                State = model.State,
                Zip = model.Zip
            };
        }
    }
}
