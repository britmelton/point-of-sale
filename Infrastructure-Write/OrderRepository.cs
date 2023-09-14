using Domain;
using System.Linq.Expressions;

namespace Infrastructure.Write
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public void CreateOrder(Domain.Order order)
        {
            var dbOrder = new Order(order);

            _context.Order.Add(dbOrder);
            _context.SaveChanges();
        }

        private Domain.Order Find(Expression<Func<Order, bool>> predicate) => _context.Order.First(predicate);
        public Domain.Order Find(Guid id) => Find(x => x.Id == id);
        private Order FindInf(Expression<Func<Order, bool>> predicate) => _context.Order.First(predicate);
        public Order FindInf(Guid id) => FindInf(x => x.Id == id);

        public void Update(Domain.Order order)
        {
            var storedOrder = FindInf(order.Id);
            storedOrder.Update(order);

            _context.SaveChanges();
        }
    }
}