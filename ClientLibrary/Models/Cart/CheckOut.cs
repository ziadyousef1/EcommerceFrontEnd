

public class CheckOut
{
    public Guid PaymentMethodId { get; set; }
    public IEnumerable<ProcessCart> CartItems { get; set; }
}