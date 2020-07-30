namespace Infrastructure.Security
{
    using System.Threading.Tasks;
    using Application.Interfaces;

    using MercadoPago.Resources;
    using MercadoPago.DataStructures.Payment;
    using Application.Payment.Request;

    public class PaymentGenerator : IPayment
    {
        public Task AddPayment(PaymentRequest request)
        {
            MercadoPago.SDK sdk = new MercadoPago.SDK();
            sdk.AccessToken = "TEST-3608427417464721-073000-42f3f9630fd48fff74e943408dba0f5c-477209537";
            
            Payment payment = new Payment(sdk)
            {
                TransactionAmount = request.Amount,
                Token = request.Token,
                Description = request.Description,
                PaymentMethodId = request.PaymentMethodId,
                Installments = 1,
                Payer = new Payer
                {
                    Email = request.PayerEmail
                }
            };

            payment.Save();

            return Task.FromResult(payment.Status);
        }
    }
}
