using Database.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPaymentsForProperty(int id);
        IEnumerable<Payment> GetPaymentsForPropertyWithLastAmount(int id, int lastAmount);
    }
}
