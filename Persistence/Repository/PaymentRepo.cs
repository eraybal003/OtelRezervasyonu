using Domain.Entites;
using Persistence.Context;
using Persistence.IRepository;

namespace Persistence.Repository;

public class PaymentRepo : Repository<Payment>, IPayment
{
    public PaymentRepo(AppDBContext context) : base(context)
    {
    }
}
