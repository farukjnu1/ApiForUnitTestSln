using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiForUnitTest.Controllers;
using ApiForUnitTest.Interfaces;
using ApiForUnitTest.Models;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestsByMSTest
{
    [TestClass]
    public class EmployeesControllerTests
    {
        private Mock<IEmployeeRepository> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeesController _empController;

        public EmployeesControllerTests() 
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeRepository>();
        }

        [TestMethod]
        public async Task GetAll_Ok()
        {
            var employeeList = _fixture.CreateMany<Employee>(3).ToList();

            _employeeRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employeeList);

            _empController = new EmployeesController(_employeeRepoMock.Object);

            var result = await _empController.GetAll();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetAll_ThrowException()
        {
            _employeeRepoMock.Setup(repo => repo.GetAllAsync()).ThrowsAsync(new Exception());

            _empController = new EmployeesController(_employeeRepoMock.Object);

            var result = await _empController.GetAll();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetById_Ok()
        {
            var employee = _fixture.Create<Employee>();

            _employeeRepoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            _empController = new EmployeesController(_employeeRepoMock.Object);

            var result = await _empController.GetById(employee.Id);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetEmployeeByName_Ok()
        {
            var employee = _fixture.Create<Employee>();

            _employeeRepoMock.Setup(repo => repo.GetEmployeeByNameAsync(It.IsAny<string>())).ReturnsAsync(employee);

            _empController = new EmployeesController(_employeeRepoMock.Object);

            var result = await _empController.GetByName(employee.FullName);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task Create_Ok()
        {
            var employee = _fixture.Create<Employee>();

            _employeeRepoMock.Setup(repo => repo.AddAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            _empController = new EmployeesController(_employeeRepoMock.Object);

            var result = await _empController.Create(employee);
            var obj = result as ObjectResult;

            Assert.AreEqual(201, obj.StatusCode);
        }

    }
}
