using PropertyServices.Database.Models;

namespace PropertyServices.DataAccess.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPaymentsForProperty(int id);
        IEnumerable<Payment> GetPaymentsForPropertyWithLastAmount(int id, int lastAmount);
    }
}
