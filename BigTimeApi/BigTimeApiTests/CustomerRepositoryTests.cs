using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BigTimeApi;

namespace BigTimeApiTests
{
    //[TestClass]
    //public class CustomerRepositoryTests
    //{
    //    private Mock<DataContext> _mockContext;
    //    private Mock<IDbConnection> _mockConnection;
    //    private CustomerRepository _repository;

    //    [TestInitialize]
    //    public void Setup()
    //    {
    //        _mockContext = new Mock<DataContext>();
    //        _mockConnection = new Mock<IDbConnection>();
    //        _mockContext.Setup(c => c.CreateConnection()).Returns(_mockConnection.Object);
    //        _repository = new CustomerRepository(_mockContext.Object);
    //    }

    //    [TestMethod]
    //    public void GetCustomerById_ReturnsCustomer()
    //    {
    //        // Arrange
    //        var customerId = 1;
    //        var sql = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
    //        var customer = new Customer { CustomerId = customerId, Address = new Address() };
    //        var customers = new List<Customer> { customer };
    //        _mockConnection.Setup(c => c.Query<Customer, Address, Customer>(
    //            sql,
    //            It.IsAny<Func<Customer, Address, Customer>>(),
    //            new { CustomerId = customerId },
    //            null,
    //            false,
    //            "Street",
    //            null))
    //            .Returns(customers);

    //        // Act
    //        var result = _repository.GetCustomerById(customerId);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(customerId, result.CustomerId);
    //    }

    //    [TestMethod]
    //    public void GetList_ReturnsListOfCustomers()
    //    {
    //        // Arrange
    //        var sql = "SELECT * FROM Customer";
    //        var customers = new List<Customer> { new Customer { CustomerId = 1, Address = new Address() } };
    //        _mockConnection.Setup(c => c.Query<Customer, Address, Customer>(
    //            sql,
    //            It.IsAny<Func<Customer, Address, Customer>>(),
    //            null,
    //            null,
    //            false,
    //            "Street",
    //            null))
    //            .Returns(customers);

    //        // Act
    //        var result = _repository.GetList();

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(1, result.Count());
    //    }

    //    [TestMethod]
    //    public void GetNewCustomer_ReturnsNewCustomer()
    //    {
    //        // Act
    //        var result = _repository.GetNewCustomer();

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.IsInstanceOfType(result, typeof(Customer));
    //    }

    //    [TestMethod]
    //    public void Save_ExistingCustomer_CallsUpdate()
    //    {
    //        // Arrange
    //        var customer = new Mock<ICustomer>();
    //        customer.Setup(c => c.CustomerId).Returns(1);
    //        _mockConnection.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<object>()));

    //        // Act
    //        _repository.Save(customer.Object);

    //        // Assert
    //        _mockConnection.Verify(c => c.Execute(It.Is<string>(s => s.StartsWith("UPDATE")), It.IsAny<object>()), Times.Once);
    //    }

    //    [TestMethod]
    //    public void Save_NewCustomer_CallsCreate()
    //    {
    //        // Arrange
    //        var customer = new Mock<ICustomer>();
    //        customer.Setup(c => c.CustomerId).Returns((int?)null);
    //        _mockConnection.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<object>()));

    //        // Act
    //        _repository.Save(customer.Object);

    //        // Assert
    //        _mockConnection.Verify(c => c.Execute(It.Is<string>(s => s.StartsWith("INSERT")), It.IsAny<object>()), Times.Once);
    //    }
    //}
}
