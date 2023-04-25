namespace domain
{
    public class Order
    {
        public Guid Id { get; }

        public Order(Guid id = default)
        {
            Id = id == default ? Guid.NewGuid() : id;
        }
    }
}
