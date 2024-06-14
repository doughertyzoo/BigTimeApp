namespace BigTimeApi
{
    public interface ICustomerFactory
    {
        ICustomer CreateCustomer(CreateCustomerRequestModel model);
        ICustomer CreateCustomer(UpdateCustomerRequestModel model);
    }
}
