namespace BigTimeApi
{
    public interface ICustomerService
    {
        IEnumerable<ICustomer> GetList();
        ICustomer GetNewCustomer();
        ICustomer? GetCustomerById(int id);
        void Save(ICustomer customer);
        void Delete(int id);
    }
}
