using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerCallback.Data
{
    public class CustomerCallbackRepo : ICustomerCallbackRepo
    {
        private readonly CustomerCallbackContext _db;

        public CustomerCallbackRepo(CustomerCallbackContext db)
        {
            _db = db;
        }

        public IQueryable<Models.CustomerCallback> CustomerCallbacks()
        {
            return _db.CustomerCallbacks;
        }

        public void Add(Models.CustomerCallback customerCallback)
        {
            _db.CustomerCallbacks.Add(customerCallback);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
