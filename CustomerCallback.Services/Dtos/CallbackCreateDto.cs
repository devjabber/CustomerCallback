using CustomerCallback.Services.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerCallback.Services.Dtos
{
    public class CallbackCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [CallbackDateTimeValidator]
        public DateTime CallbackDateTime { get; set; }
    }    
}
