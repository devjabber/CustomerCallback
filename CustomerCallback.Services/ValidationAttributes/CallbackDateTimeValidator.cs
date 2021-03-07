using CustomerCallback.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerCallback.Services.ValidationAttributes
{
    public class CallbackDateTimeValidator : ValidationAttribute
    {        
        public string GetErrorMessage() =>
        $"Callback date cannot be in the past.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var callbackCreateDto = (CallbackCreateDto)validationContext.ObjectInstance;

            if (callbackCreateDto.CallbackDateTime < DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
