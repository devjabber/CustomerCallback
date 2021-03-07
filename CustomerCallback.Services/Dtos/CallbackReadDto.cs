using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerCallback.Services.Dtos
{
    public class CallbackReadDto
    {        
        public int Id { get; set; }                
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public string MobileNumber { get; set; }        
        public DateTime CallbackDateTime { get; set; }
    }
}
