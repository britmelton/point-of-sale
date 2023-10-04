namespace App.Services;

public interface IOrderService
{
    public Guid SubmitOrder(SubmitOrderCommand args);

}