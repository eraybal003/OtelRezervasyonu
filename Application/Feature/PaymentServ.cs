using Application.DTO;
using Domain.Entites;
using Persistence.IRepository;

namespace Application.Feature;

public class PaymentServ(IPayment payment)
{
   public  IEnumerable<PaymentDTO> GetPayments()
    {
        List<PaymentDTO> payments = [];
        foreach (Payment item in payment.GetAll())
        {
            payments.Add(new(item.Id,item.ReservationID,item.Amount,item.PaymentDate,
                item.PaymentMethod,item.Status,item.Reservation));
        }
        return payments;
    }
    public PaymentDTO GetById(Ulid id)
    {
        var pay = payment.FindOne(p => p.Id == id);
        if (pay == null)
        {
            return new(default, default, default, default, string.Empty, string.Empty, default);
        }
        return new(pay.Id, pay.ReservationID, pay.Amount, pay.PaymentDate, pay.PaymentMethod, pay.Status, pay.Reservation);
    }
    public PaymentDTO GetByMethod(string method)
    {
        var pay = payment.FindOne(p => p.PaymentMethod == method);
        if (pay == null)
        {
            return new(default, default, default, default, string.Empty, string.Empty, default);
        }
        return new(pay.Id, pay.ReservationID, pay.Amount, pay.PaymentDate, pay.PaymentMethod, pay.Status, pay.Reservation);
    }
    public PaymentDTO GetByStatus(string status)
    {
        var pay = payment.FindOne(p => p.Status == status);
        if (pay == null)
        {
            return new(default, default, default, default, string.Empty, string.Empty, default);
        }
        return new(pay.Id, pay.ReservationID, pay.Amount, pay.PaymentDate, pay.PaymentMethod, pay.Status, pay.Reservation);
    }
    public void Add(PaymentCreateDTO paymentCreate)
    {
        payment.Add(new()
        {
            Amount = paymentCreate.amount,
            PaymentMethod = paymentCreate.paymentmethod,
            Status = paymentCreate.status
        });
    }
    public void Update(PaymentUpdateDTO paymentUpdate)
    {
        payment.Update(new()
        {
            Amount = paymentUpdate.amount,
            PaymentMethod = paymentUpdate.paymentmethod,
            Status = paymentUpdate.status
        });
    }
    public void Delete(PaymentDeleteDTO paymentDelete)
    {
        payment.Delete(new()
        {
            Id = paymentDelete.id

        });
    }
    
}
