using AutoMapper;
using CustomerCallback.Data;
using CustomerCallback.Services.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerCallback.Services
{
    public class CustomerCallbackService : ICustomerCallbackService
    {
        private ICustomerCallbackRepo _customerCallbackRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerCallbackService> _logger;

        public CustomerCallbackService(ICustomerCallbackRepo customerCallbackRepo, IMapper mapper, ILogger<CustomerCallbackService> logger)
        {
            _customerCallbackRepo = customerCallbackRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public void AddCallback(CallbackCreateDto callbackCreateDto)
        {
            var callBackModel = _mapper.Map<Data.Models.CustomerCallback>(callbackCreateDto);

            _customerCallbackRepo.Add(callBackModel);
            _customerCallbackRepo.SaveChanges();
        }

        public IEnumerable<CallbackReadDto> GetAllCallbacks()
        {
            var callbacks = _customerCallbackRepo.CustomerCallbacks();
            _logger.LogInformation($"Returning {callbacks.Count()} callbacks");
            return _mapper.Map<IEnumerable<CallbackReadDto>>(callbacks);
        }
    }
}
