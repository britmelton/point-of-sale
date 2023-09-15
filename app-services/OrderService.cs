using Domain;

namespace App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Guid SubmitOrder(SubmitOrderCommand args)
        {
            var lineItems = args.LineItems;
            var order = new Order();

            foreach (var item in lineItems)
            {
                order.AddLineItem(item.ProductId, item.Quantity, item.Price);
            }
            order.Submit();

            _orderRepo.CreateOrder(order);
            _orderRepo.Update(order);

            return order.Id;
        }
    }
}