using System.Linq;

namespace CustomerCallback.Data
{
    public interface ICustomerCallbackRepo
    {
        void Add(Models.CustomerCallback customerCallback);
        IQueryable<Models.CustomerCallback> CustomerCallbacks();
        void SaveChanges();
    }
}