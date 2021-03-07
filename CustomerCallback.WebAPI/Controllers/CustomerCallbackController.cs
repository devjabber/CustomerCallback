using CustomerCallback.Services;
using CustomerCallback.Services.Dtos;
using CustomerCallback.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCallback.WebAPI.Controllers
{
    [Route("api/CustomerCallback")]
    [ApiController]
    public class CustomerCallbackController : ControllerBase
    {
        private readonly ILogger<CustomerCallbackController> _logger;
        private ICustomerCallbackService _customerCallbackService;

        public CustomerCallbackController(ILogger<CustomerCallbackController> logger, ICustomerCallbackService customerCallbackService)
        {
            _logger = logger;
            _customerCallbackService = customerCallbackService;
        }

        [HttpPost]
        public ActionResult AddCallback(CallbackCreateDto callbackCreateDto)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidCallbackDateTimeException(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            }

            _customerCallbackService.AddCallback(callbackCreateDto);            
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CallbackReadDto>> GetAllCallbacks()
        {
            var callbacks = _customerCallbackService.GetAllCallbacks();

            if (!callbacks.Any())
            {                 
                return NotFound();
            }


            _logger.LogInformation($"Returning {callbacks.Count()} Callback records.");
            return Ok(callbacks);
        }
    }
}
