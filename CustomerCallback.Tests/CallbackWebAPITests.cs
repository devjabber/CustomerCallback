using CustomerCallback.Data;
using CustomerCallback.Services;
using CustomerCallback.Services.Dtos;
using CustomerCallback.Services.Exceptions;
using CustomerCallback.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerCallback.Tests
{
    public class CallbackWebAPITests
    {
        private const int NOT_FOUND = 404;

        [Fact]
        public void AddCallback_WhenModelValidationFails_Throws_InvalidCallbackDateTimeException()
        {
            //Arrange
            var customerCallbackService = new Mock<ICustomerCallbackService>();
            var callbackCreateDto = new CallbackCreateDto() { CallbackDateTime = DateTime.Now.AddYears(-1) };
            var logger = new Mock<ILogger<CustomerCallbackController>>();
            var controller = new CustomerCallbackController(logger.Object, customerCallbackService.Object);
            controller.ModelState.AddModelError("", "");

            //Act
            //Assert
            Assert.Throws<InvalidCallbackDateTimeException>(() => controller.AddCallback(callbackCreateDto));
        }

        [Fact]
        public void GetAllCallbacks_WhenNoRecordsFound_ReturnsNotFoundResult()
        {
            //Arrange
            var customerCallbackService = new Mock<ICustomerCallbackService>();
            var customerCallbackRepo = new Mock<ICustomerCallbackRepo>();
            var logger = new Mock<ILogger<CustomerCallbackController>>();
            customerCallbackRepo.Setup(x => x.CustomerCallbacks()).Returns(new List<CustomerCallback.Data.Models.CustomerCallback>().AsQueryable());
            var controller = new CustomerCallbackController(logger.Object, customerCallbackService.Object);

            //Act
            var response = controller.GetAllCallbacks();
            var statusCode = response.Result as StatusCodeResult;

            //Assert
            Assert.Equal(NOT_FOUND, statusCode.StatusCode);
        }
    }
}
