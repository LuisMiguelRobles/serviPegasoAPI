using Application.Payment.Request;

namespace Application.Interfaces
{
    using System.Threading.Tasks;

    public interface IPayment
    {
        Task<string> AddPayment(PaymentRequest paymentRequest);
    }
}
