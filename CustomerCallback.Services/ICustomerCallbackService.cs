using CustomerCallback.Services.Dtos;
using System.Collections.Generic;

namespace CustomerCallback.Services
{
    public interface ICustomerCallbackService
    {
        void AddCallback(CallbackCreateDto callbackCreateDto);
        IEnumerable<CallbackReadDto> GetAllCallbacks();
    }
}