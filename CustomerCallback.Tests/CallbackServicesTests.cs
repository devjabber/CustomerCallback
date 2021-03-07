using AutoMapper;
using CustomerCallback.Data;
using CustomerCallback.Services;
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
    public class CallbackServicesTests
    {
        [Fact]
        public void AddCallback_Calls_Add_And_SaveChanges()
        {
            //Arrange
            var customerCallbackRepo = new Mock<ICustomerCallbackRepo>();
            var logger = new Mock<ILogger<CustomerCallbackService>>();
            var mapper = new Mock<IMapper>();

            customerCallbackRepo.Setup(x => x.Add(It.IsAny<Data.Models.CustomerCallback>()));
            customerCallbackRepo.Setup(x => x.SaveChanges());

            var customerCallbackService = new CustomerCallbackService(customerCallbackRepo.Object, mapper.Object, logger.Object);
            var dto = new Services.Dtos.CallbackCreateDto();

            //Act
            customerCallbackService.AddCallback(dto);

            //Assert
            customerCallbackRepo.Verify(x => x.Add(It.IsAny<Data.Models.CustomerCallback>()), Times.Once());
            customerCallbackRepo.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
