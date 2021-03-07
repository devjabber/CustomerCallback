using AutoMapper;
using CustomerCallback.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCallback.Services.Profiles
{
    public class CustomerCallbackProfile : Profile
    {
        public CustomerCallbackProfile()
        {
            CreateMap<CallbackCreateDto, Data.Models.CustomerCallback>();
            CreateMap<Data.Models.CustomerCallback, CallbackReadDto>();
        }
    }
}
