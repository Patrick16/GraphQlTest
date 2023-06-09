﻿using PropertyService.Database;
using PropertyService.Database.Models;
using PropertyService.Repositories.Interfaces;

namespace PropertyService.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MyDbContext _db;

        public PaymentRepository(MyDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Payment> GetPaymentsForProperty(int id)
        {
            return _db.Payments.Where(p => p.PropertyId == id);
        }

        public IEnumerable<Payment> GetPaymentsForPropertyWithLastAmount(int id, int lastAmount)
        {
            return _db.Payments.Where(p => p.PropertyId == id)
                .OrderByDescending(c => c.DateCreated)
                .Take(lastAmount);
        }
    }
}
