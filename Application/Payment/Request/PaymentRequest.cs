namespace Application.Payment.Request
{
    public class PaymentRequest
    {
        public string Token { get; set; }
        public float Amount { get; set; }
        public string PayerEmail { get; set; }
        public string PaymentMethodId { get; set; }
        public string Description { get; set; }
    }
}
