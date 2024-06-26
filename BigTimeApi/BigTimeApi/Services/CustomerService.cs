﻿namespace BigTimeApi
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private ICustomerFactory _customerFactory;

        public CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
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

        public void Create(CreateCustomerRequestModel model)
        {
            ICustomer? customer = _customerFactory.CreateCustomer(model);
            Save(customer);
        }

        public void Update(UpdateCustomerRequestModel model)
        {
            ICustomer? customer = _customerFactory.CreateCustomer(model);
            Save(customer);
        }

        public void Save(ICustomer customer)
        {
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer does not exist");
            }

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
