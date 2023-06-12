using PropertyService.Database.Models;

namespace PropertyService.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPaymentsForProperty(int id);
        IEnumerable<Payment> GetPaymentsForPropertyWithLastAmount(int id, int lastAmount);
    }
}
