using BigTimeApi;
using Moq;

namespace BitTimeApiTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository>? _mockCustomerRepository;
        private ICustomerService? _customerService;

        [TestInitialize]
        public void Setup()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockCustomerRepository.Object);
        }

        [TestMethod]
        public void Delete_CustomerExists_DeletesSuccessfully()
        {
            var customerId = 1;
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns(new Customer { CustomerId = customerId });
            _customerService!.Delete(customerId);
            _mockCustomerRepository.Verify(repo => repo.Delete(customerId), Times.Once);
        }

        [TestMethod]
        public void Delete_CustomerDoesNotExist_ThrowsException()
        {
            var customerId = 1;
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns((ICustomer)null);
            Assert.ThrowsException<AppException>(() => _customerService!.Delete(customerId));
        }

        [TestMethod]
        public void GetCustomerById_ValidId_ReturnsCustomer()
        {
            var customerId = 1;
            var expectedCustomer = new Customer { CustomerId = customerId };
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns(expectedCustomer);
            var result = _customerService!.GetCustomerById(customerId);
            Assert.AreEqual(expectedCustomer, result);
        }

        [TestMethod]
        public void GetCustomerById_InvalidId_ReturnsNull()
        {
            var customerId = 1;
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns((ICustomer)null);
            var result = _customerService!.GetCustomerById(customerId);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetList_ReturnsListOfCustomers()
        {
            var expectedCustomers = new List<ICustomer>
            {
                new Customer { CustomerId = 1 },
                new Customer { CustomerId = 2 }
            };
            _mockCustomerRepository!.Setup(repo => repo.GetList()).Returns(expectedCustomers);
            var result = _customerService!.GetList().ToList();
            CollectionAssert.AreEqual(expectedCustomers, result);
        }

        [TestMethod]
        public void GetNewCustomer_ReturnsNewCustomer()
        {
            var expectedCustomer = new Customer();
            _mockCustomerRepository!.Setup(repo => repo.GetNewCustomer()).Returns(expectedCustomer);
            var result = _customerService!.GetNewCustomer();
            Assert.AreEqual(expectedCustomer, result);
        }

        [TestMethod]
        public void Save_NewCustomerWithMissingLastName_ThrowsException()
        {
            var customer = new Customer { CompanyName = "WWW" };
            Assert.ThrowsException<AppException>(() => _customerService!.Save(customer));
        }

        [TestMethod]
        public void Save_NewCustomerWithMissingCompanyName_ThrowsException()
        {
            var customer = new Customer { LastName = "WWW" };
            Assert.ThrowsException<AppException>(() => _customerService!.Save(customer));
        }

        [TestMethod]
        public void Save_NewCustomerWithMissingLastAndCompanyName_ThrowsException()
        {
            var customer = new Customer();
            Assert.ThrowsException<AppException>(() => _customerService!.Save(customer));
        }

        [TestMethod]
        public void Save_ExistingCustomerThatDoesNotExist_ThrowsException()
        {
            var customer = new Customer { CustomerId = 1, LastName = "QQQ", CompanyName = "WWW" };
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customer.CustomerId.Value)).Returns((ICustomer)null);
            Assert.ThrowsException<AppException>(() => _customerService!.Save(customer));
        }

        [TestMethod]
        public void Save_ExistingCustomerExists_SavesSuccessfully()
        {
            var customer = new Customer { CustomerId = 1, LastName = "QQQ", CompanyName = "WWW" };
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customer.CustomerId.Value)).Returns(customer);
            _customerService!.Save(customer);
            _mockCustomerRepository.Verify(repo => repo.Save(customer), Times.Once);
        }
    }
}