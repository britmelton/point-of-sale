using Domain;

namespace App.Services;

    public interface ICartService
    {
        public Cart Add(AddLineItemsCommand args);
        public Guid GenerateCart();
    }