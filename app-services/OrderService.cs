using Domain;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;

    #region Creation

    public OrderService(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    #endregion

    #region IOrderService Implementation

    public Guid SubmitOrder(SubmitOrderCommand args)
    {
        var order = new SubmitOrderBuilder()
            .Load(args.LineItems)
            .Build()
            .GetOrder();
        order.Submit();

        _orderRepo.CreateOrder(order);
        _orderRepo.Update(order);

        return order.Id;
    }

    #endregion
}