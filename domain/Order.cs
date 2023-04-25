namespace domain
{
    public class Order
    {
        public Guid Id { get; }
        public string OrderNumber { get; set; }

        public Order(string orderNubmer, Guid id = default)
        {
            OrderNumber = orderNubmer;
            Id = id == default ? Guid.NewGuid() : id;
        }
    }
}
