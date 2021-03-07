using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCallback.Data
{
    public class CustomerCallbackContext : DbContext
    {
        public CustomerCallbackContext(DbContextOptions<CustomerCallbackContext> options): base(options)
        {
        }

        public DbSet<Models.CustomerCallback> CustomerCallbacks { get; set; }
    }
}
