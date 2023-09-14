using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write
{
    public class Product : Entity
    {
        public Product() { }

        public Product(Domain.Product product) : base(product.Id)
        {
            Name = product.Name;
            Price = product.Price;
            QuantityOnHand = product.QuantityOnHand;
            Sku = product.Sku;
        }

        public string Name { get; set; }
        [Precision(6, 2)]
        public decimal Price { get; set; }
        public ushort QuantityOnHand { get; set; }
        public string Sku { get; set; }

        public static implicit operator Domain.Product(Product source) =>
            new(source.Name, source.Price, source.Sku, source.QuantityOnHand, source.Id);

        public static implicit operator Product(Domain.Product source) => new(source);

        public Product Update(Domain.Product product)
        {
            Name = product.Name;
            Price = product.Price;
            QuantityOnHand = product.QuantityOnHand;
            Sku = product.Sku;

            return this;
        }
    }
}