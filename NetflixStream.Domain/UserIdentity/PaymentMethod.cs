
namespace NetflixStream.Domain.UserIdentity
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; } = string.Empty; 
        public bool IsActive { get; set; } = true; 
        public decimal ProcessingFee { get; set; } 
        public ICollection<Payments>? Payments { get; set; }
    }
}