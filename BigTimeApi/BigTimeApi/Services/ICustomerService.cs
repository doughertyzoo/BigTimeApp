namespace BigTimeApi
{
    public interface ICustomerService
    {
        IEnumerable<ICustomer> GetList();
        ICustomer GetNewCustomer();
        ICustomer? GetCustomerById(int id);
        void Create(CreateCustomerRequestModel model);
        void Update(UpdateCustomerRequestModel model);
        void Delete(int id);
    }
}
