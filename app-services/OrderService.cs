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
            var builder = new SubmitOrderBuilder();
            builder.Load(args.LineItems);
            builder.Build();
            var order = builder.GetOrder();

            order.Submit();

            _orderRepo.CreateOrder(order);
            _orderRepo.Update(order);

            return order.Id;
        }
    }

    public class SubmitOrderBuilder : Order.Builder
    {
        private List<LineItem> _lineItems = new();
        private IEnumerator<LineItem> _enumerator;
        public override void AddLineItem()
        {
            var lineItem = _enumerator.Current;
            Order.AddLineItem(lineItem.ProductId, lineItem.Quantity, lineItem.Price);
        }

        public override bool Next() => _enumerator.MoveNext();

        public Order GetOrder() => Order;

        public void Load(IEnumerable<LineItem> lineItems)
        {
            _lineItems.Clear();
            _lineItems.AddRange(lineItems);
            _enumerator = _lineItems.GetEnumerator();
        }
    }
}