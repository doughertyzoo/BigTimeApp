using AutoMapper;

namespace BigTimeApi
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Delete(int id)
        {
            if (_customerRepository.GetCustomerById(id) == null)
            {
                throw new AppException("Customer does not exist; cannot delete");
            }
            _customerRepository.Delete(id);
        }

        public ICustomer? GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return customer;
        }

        public IEnumerable<ICustomer> GetList()
        {
            var customers = _customerRepository.GetList();
            return customers;
        }

        public ICustomer GetNewCustomer()
        {
            var customer = _customerRepository.GetNewCustomer();
            return customer;
        }

        public void Save(ICustomer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.LastName) || string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                throw new AppException("Customer needs a LastName and a CompanyName");
            }

            if (customer.CustomerId.HasValue)
            {
                if (_customerRepository.GetCustomerById(customer.CustomerId.Value) == null)
                {
                    throw new AppException("Customer does not exist; cannot update");
                }

            }

            _customerRepository.Save(customer);
        }
    }
}
