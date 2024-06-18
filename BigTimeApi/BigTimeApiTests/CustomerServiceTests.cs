using BigTimeApi;
using Castle.Core.Resource;
using Moq;

namespace BitTimeApiTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository>? _mockCustomerRepository;
        private Mock<ICustomerFactory>? _mockCustomerFactory;
        private ICustomerService? _customerService;

        [TestInitialize]
        public void Setup()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockCustomerFactory = new Mock<ICustomerFactory>();
            _customerService = new CustomerService(_mockCustomerRepository.Object, _mockCustomerFactory.Object);
        }

        [TestMethod]
        public void Delete_CustomerExists_DeletesSuccessfully()
        {
            var customerId = 1;
            ICustomer customer = new CustomerDto { CustomerId = customerId };
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns(customer);
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
            ICustomer customer = new CustomerDto { CustomerId = customerId };
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns(customer);
            var result = _customerService!.GetCustomerById(customerId);
            Assert.AreEqual(customer, result);
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
            List<ICustomer> expectedCustomers = new List<ICustomer>
            {
                new CustomerDto { CustomerId = 1 },
                new CustomerDto { CustomerId = 2 }
            };
            _mockCustomerRepository!.Setup(repo => repo.GetList()).Returns(expectedCustomers);
            var result = _customerService!.GetList().ToList();
            CollectionAssert.AreEqual(expectedCustomers, result);
        }

        [TestMethod]
        public void GetNewCustomer_ReturnsNewCustomer()
        {
            ICustomer customer = new CustomerDto();
            _mockCustomerRepository!.Setup(repo => repo.GetNewCustomer()).Returns(customer);
            var result = _customerService!.GetNewCustomer();
            Assert.AreEqual(customer, result);
        }

        [TestMethod]
        public void Create_MissingLastName_ThrowsException()
        {
            ICustomer customer = new CustomerDto { CompanyName = "WWW" };
            CreateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns(customer);
            Assert.ThrowsException<AppException>(() => _customerService!.Create(mockModel));
        }

        [TestMethod]
        public void Create_MissingCompanyName_ThrowsException()
        {
            ICustomer customer = new CustomerDto { LastName = "WWW" };
            CreateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns(customer);
            Assert.ThrowsException<AppException>(() => _customerService!.Create(mockModel));
        }

        [TestMethod]
        public void Create_MissingLastAndCompanyName_ThrowsException()
        {
            ICustomer customer = new CustomerDto();
            CreateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns(customer);
            Assert.ThrowsException<AppException>(() => _customerService!.Create(mockModel));
        }

        [TestMethod]
        public void Create_ExistingCustomerExists_SavesSuccessfully()
        {
            ICustomer customer = new CustomerDto { LastName = "QQQ", CompanyName = "WWW" };
            CreateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns(customer);
            _customerService!.Create(mockModel);
            _mockCustomerRepository!.Verify(repo => repo.Save(customer), Times.Once);
        }

        [TestMethod]
        public void Update_ExistingCustomerThatDoesNotExist_ThrowsException()
        {
            UpdateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns((ICustomer)null);
            Assert.ThrowsException<KeyNotFoundException>(() => _customerService!.Update(mockModel));
        }

        [TestMethod]
        public void Update_ExistingCustomerExists_SavesSuccessfully()
        {
            var customerId = 1;
            ICustomer customer = new CustomerDto { CustomerId = customerId, LastName = "QQQ", CompanyName = "WWW" };
            UpdateCustomerRequestModel mockModel = new();
            _mockCustomerFactory!.Setup(fact => fact.CreateCustomer(mockModel)).Returns(customer);
            _mockCustomerRepository!.Setup(repo => repo.GetCustomerById(customerId)).Returns(customer);
            _customerService!.Update(mockModel);
            _mockCustomerRepository.Verify(repo => repo.Save(customer), Times.Once);
        }
    }
}