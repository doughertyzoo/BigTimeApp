
using Dapper;

namespace BigTimeApi
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            using var connection = _context.CreateConnection();
            string sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
            connection.Execute(sql, new { CustomerId = id });
        }

        public ICustomer? GetCustomerById(int id)
        {
            using var connection = _context.CreateConnection();
            string sql = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
            var result = connection.Query<Customer, Address, Customer>(
                sql,
                (customer, address) =>
                {
                    customer.Address = address;
                    return customer;
                },
                new { CustomerId = id },
                splitOn: "Street"
            ).FirstOrDefault();

            return result;
        }

        public IEnumerable<ICustomer> GetList()
        {
            using var connection = _context.CreateConnection();
            string sql = "SELECT * FROM Customer";
            var result = connection.Query<Customer, Address, Customer>(
                sql,
                (customer, address) =>
                {
                    customer.Address = address;
                    return customer;
                },
                splitOn: "Street"
            ).ToList();

            return result;
        }

        public ICustomer GetNewCustomer()
        {
            return new Customer();
        }

        public void Save(ICustomer customer)
        {
            if (customer.CustomerId.HasValue)
            {
                Update(customer);
            }
            else
            {
                Create(customer);
            }
        }

        private void Create(ICustomer customer)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                INSERT INTO Customer (FirstName, LastName, CompanyName, Street, City, State, Zip)
                VALUES (@FirstName, @LastName, @CompanyName, @Street, @City, @State, @Zip)
            """;
            var parameters = new
            {
                customer.FirstName,
                customer.LastName,
                customer.CompanyName,
                customer.Address.Street,
                customer.Address.City,
                customer.Address.State,
                customer.Address.Zip
            };

            connection.Execute(sql, parameters);
        }

        private void Update(ICustomer customer)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                UPDATE Customer
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    CompanyName = @CompanyName, 
                    Street = @Street, 
                    City = @City, 
                    State = @State,
                    Zip = @Zip
                WHERE CustomerId = @CustomerId
            """;
            var parameters = new
            {
                customer.FirstName,
                customer.LastName,
                customer.CompanyName,
                customer.Address.Street,
                customer.Address.City,
                customer.Address.State,
                customer.Address.Zip,
                customer.CustomerId
            };
            connection.Execute(sql, parameters);
        }
    }
}
