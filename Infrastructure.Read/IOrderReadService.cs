namespace Infrastructure.Read
{
    public interface IOrderReadService
    {
        public Order Find(Guid id);

    }
}