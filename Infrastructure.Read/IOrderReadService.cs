namespace Infrastructure.Read;

public interface IOrderReadService
{
    public OrderDto Find(Guid id);
}