namespace Domain;

public interface IOrderRepository
{
    public void CreateOrder(Order order);
    public Order Find(Guid id);
    public void Update(Order order);
}